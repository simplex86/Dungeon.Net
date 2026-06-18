using System;
using System.Collections.Generic;
using System.Linq;

namespace SimplexLab.Dungeon
{
    /// <summary>
    /// 矩形地牢
    /// </summary>
    internal class RectangularDungeonOverlaprProvider : IRectangularDungeonProvider
    {
        // 随机数
        private Random random = null;
        // 
        private int currentRegion = -1;
        // 
        private int[,] regions = null;

        /// <summary>
        /// 邻居的方位
        /// </summary>
        private static readonly Vector[] CARDINAL_DIR = new Vector[] {
            new Vector( 0, -1), //上
            new Vector( 0,  1), //下
            new Vector(-1,  0), //左
            new Vector( 1,  0), //右
        };

        //
        private int minRoomWidth = 3;
        //
        private int maxRoomWidth = 7;
        //
        private int minRoomHeight = 3;
        //
        private int maxRoomHeight = 7;
        //
        private int maxRoomCount = 5;
        // 
        private int mulConnector = 5;
        // 曲折度
        private int tortuosity = 50;

        /// <summary>
        /// 
        /// </summary>
        public DungeonAlgorithm algorithm { get; } = DungeonAlgorithm.OverlapR;

        /// <summary>
        /// 创建地牢
        /// </summary>
        /// <returns></returns>
        public RectangularDungeonField Create(int width, 
                                              int height, 
                                              int minRoomWidth, 
                                              int maxRoomWidth, 
                                              int minRoomHeight, 
                                              int maxRoomHeight, 
                                              int maxRoomCount, 
                                              int mulConnector,
                                              int tortuosity)
        {
            width = Utils.Odd(width);
            height = Utils.Odd(height);

            this.minRoomWidth = Utils.Odd(minRoomWidth);
            this.maxRoomWidth = Utils.Odd(maxRoomWidth);
            this.minRoomHeight = Utils.Odd(minRoomHeight);
            this.maxRoomHeight = Utils.Odd(maxRoomHeight);
            this.maxRoomCount = maxRoomCount;
            this.mulConnector = mulConnector;
            this.tortuosity = Math.Clamp(tortuosity, 0, 100);
            this.random = new Random();

            currentRegion = -1;

            regions = new int[width, height];
            for (var y=0; y<height; y++)
            {
                for (var x=0; x<width; x++)
                {
                    regions[x, y] = -1;
                }
            }

            var field = new RectangularDungeonField(width, height);

            CreateRooms(field);
            CreateMaze(field);
            ConnectRegions(field);
            RemoveDeadEnds(field);

            return field;
        }

        /// <summary>
        /// 创建异形房间
        /// 每个异形房间由多个重叠的矩形组合而成，异形房间之间互不重叠
        /// </summary>
        /// <param name="field"></param>
        private void CreateRooms(RectangularDungeonField field)
        {
            var grotesqueRooms = new List<GrotesqueRoom>();

            for (var i = 0; i < maxRoomCount; i++)
            {
                if (TryCreateGrotesqueRoom(field, grotesqueRooms, out var grotesqueRoom))
                {
                    grotesqueRooms.Add(grotesqueRoom);

                    StartRegion();
                    foreach (var room in grotesqueRoom.rooms)
                    {
                        CarveRoom(field, room);
                    }
                }
            }
        }

        /// <summary>
        /// 尝试创建一个异形房间
        /// 先生成基础矩形并提前检查冲突，再增量添加额外矩形
        /// </summary>
        private bool TryCreateGrotesqueRoom(RectangularDungeonField field, List<GrotesqueRoom> existingRooms, out GrotesqueRoom grotesqueRoom)
        {
            var times = 5;

            while (times > 0)
            {
                times--;

                // 生成基础矩形
                var w = Utils.Odd(random.Next(minRoomWidth, maxRoomWidth + 1));
                var h = Utils.Odd(random.Next(minRoomHeight, maxRoomHeight + 1));
                var x = Utils.Odd(random.Next(1, field.width - w));
                var y = Utils.Odd(random.Next(1, field.height - h));

                var baseRoom = new Room(x, y, w, h);

                // 提前拒绝：基础矩形与已有房间冲突则立即重试
                var baseOverlaps = false;
                foreach (var other in existingRooms)
                {
                    if (other.IsOverlapsWith(baseRoom))
                    {
                        baseOverlaps = true;
                        break;
                    }
                }
                if (baseOverlaps) continue;

                grotesqueRoom = new GrotesqueRoom();
                grotesqueRoom.Add(baseRoom);

                // 增量添加额外矩形，每个独立检查冲突，异形房间最多由5个矩形构成
                var maxExtra = 5 - grotesqueRoom.rooms.Count;
                var extraCount = random.Next(1, maxExtra + 1);
                for (var j = 0; j < extraCount; j++)
                {
                    TryAddOverlappingRect(field, grotesqueRoom, existingRooms);
                }

                return true;
            }

            grotesqueRoom = new GrotesqueRoom();
            return false;
        }

        /// <summary>
        /// 尝试向异形房间中添加一个与已有子矩形重叠的新矩形
        /// 增量检查：新子矩形与已有房间冲突则跳过
        /// </summary>
        private void TryAddOverlappingRect(RectangularDungeonField field, GrotesqueRoom grotesqueRoom, List<GrotesqueRoom> existingRooms)
        {
            // 从已有子矩形中随机选一个作为锚点
            var anchor = grotesqueRoom.rooms[random.Next(0, grotesqueRoom.rooms.Count)];

            var nw = Utils.Odd(random.Next(minRoomWidth, maxRoomWidth + 1));
            var nh = Utils.Odd(random.Next(minRoomHeight, maxRoomHeight + 1));

            // 计算确保与锚点重叠的位置范围
            // 重叠条件: Math.Max(nx, anchor.x) < Math.Min(nx + nw, anchor.x + anchor.w)
            // 即: anchor.x - nw + 1 <= nx <= anchor.x + anchor.w - 1
            // 同时需要在场地范围内: 1 <= nx <= field.width - nw - 1
            var nxMin = Math.Max(1, anchor.x - nw + 1);
            var nxMax = Math.Min(field.width - nw - 1, anchor.x + anchor.w - 1);
            var nyMin = Math.Max(1, anchor.y - nh + 1);
            var nyMax = Math.Min(field.height - nh - 1, anchor.y + anchor.h - 1);

            if (nxMin > nxMax || nyMin > nyMax) return;

            var nx = Utils.Odd(random.Next(nxMin, nxMax + 1));
            var ny = Utils.Odd(random.Next(nyMin, nyMax + 1));

            var newRoom = new Room(nx, ny, nw, nh);

            // 增量检查：新子矩形与已有房间冲突则跳过
            foreach (var other in existingRooms)
            {
                if (other.IsOverlapsWith(newRoom))
                    return;
            }

            grotesqueRoom.Add(newRoom);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="field"></param>
        /// <param name="room"></param>
        private void CarveRoom(RectangularDungeonField field, Room room)
        {
            for (var y = room.y; y < room.y + room.h; y++)
            {
                for (var x = room.x; x < room.x + room.w; x++)
                {
                    Carve(field, x, y);
                }
            }
        }

        /// <summary>
        /// 创建空地上迷宫
        /// </summary>
        /// <param name="field"></param>
        private void CreateMaze(RectangularDungeonField field)
        {
            for (var y = 1; y < field.height; y += 2)
            {
                for (var x = 1; x < field.width; x += 2)
                {
                    if (!Utils.IsWall(field, x, y)) continue;
                    GrowMaze(field, x, y);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="field"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void GrowMaze(RectangularDungeonField field, int x, int y)
        {
            var tiles = new List<Tile>();
            var prevdir = new Vector();

            StartRegion();
            Carve(field, x, y);

            tiles.Add(new Tile(x, y));

            while (tiles.Count > 0)
            {
                var tile = tiles[tiles.Count - 1];

                var uncarves = new List<Vector>();
                foreach (var dir in CARDINAL_DIR)
                {
                    if (CanCarve(field, tile, dir)) uncarves.Add(dir);
                }

                if (uncarves.Count > 0)
                {
                    var pct = random.Next(0, 100);
                    var dir = uncarves.Contains(prevdir) && pct >= tortuosity ? prevdir 
                                                                              : uncarves[random.Next(0, uncarves.Count)];

                    var a = Find(tile, dir, 1);
                    Carve(field, a.lateral, a.radial);
                    var b = Find(tile, dir, 2);
                    Carve(field, b.lateral, b.radial);

                    tiles.Add(b);
                    prevdir = dir;
                }
                else
                {
                    tiles.RemoveAt(tiles.Count - 1);
                    prevdir = new Vector();
                }
            }
        }

        /// <summary>
        /// 雕刻
        /// </summary>
        /// <param name="field"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void Carve(RectangularDungeonField field, int x, int y)
        {
            field[x, y] = TileType.Path;
            regions[x, y] = currentRegion;
        }

        /// <summary>
        /// 判断是否可雕刻
        /// </summary>
        /// <param name="field"></param>
        /// <param name="tile"></param>
        /// <param name="dir"></param>
        /// <returns></returns>
        private bool CanCarve(in RectangularDungeonField field, Tile tile, Vector dir)
        {
            var a = Find(tile, dir, 3);
            if (a.lateral < 0 || a.lateral >= field.width ||
                a.radial < 0 || a.radial >= field.height)
            {
                return false;
            }

            var b = Find(tile, dir, 2);
            return Utils.IsWall(field, b.lateral, b.radial);
        }

        /// <summary>
        /// 
        /// </summary>
        private void StartRegion()
        {
            currentRegion++;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tile"></param>
        /// <param name="dir"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        private Tile Find(Tile tile, Vector dir, int length)
        {
            var x = tile.lateral + dir.x * length;
            var y = tile.radial + dir.y * length;

            return new Tile(x, y);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="field"></param>
        private void ConnectRegions(RectangularDungeonField field)
        {
            var connectorRegions = new Dictionary<Tile, HashSet<int>>();

            for (var y = 1; y < field.height - 1; y++)
            {
                for (var x = 1; x < field.width - 1; x++)
                {
                    var pos = new Tile(x, y);
                    if (!Utils.IsWall(field, x, y)) continue;

                    var sets = new HashSet<int>();
                    foreach (var dir in CARDINAL_DIR)
                    {
                        var region = regions[x + dir.x, y + dir.y];
                        if (region != -1)
                        {
                            sets.Add(region);
                        }
                    }

                    if (sets.Count < 2) continue;
                    connectorRegions[pos] = sets;
                }
            }
            
            var connectors = connectorRegions.Keys.ToList();

            var merged = new Dictionary<int, int>();
            var opened = new HashSet<int>();

            for (var i = 0; i <= currentRegion; i++)
            {
                merged[i] = i;
                opened.Add(i);
            }

            while (opened.Count > 1)
            {
                var connector = connectors[random.Next(0, connectors.Count)];
                AddJunction(field, connector.lateral, connector.radial);

                var list = connectorRegions[connector].Select((region) => merged[region]);
                var dest = list.First();
                var sources = list.Skip(1).ToList();

                for (int i = 0; i <= currentRegion; i++)
                {
                    if (sources.Contains(merged[i]))
                    {
                        merged[i] = dest;
                    }
                }

                opened.RemoveWhere((region) => sources.Contains(region));

                connectors.RemoveAll((pos) =>
                {
                    // 在原始算法中有这个判断，但是这里会造成connectors的数量锐减，导致最终索引越界
                    // 所以这里先注释掉了
                    // if (connector.x - pos.x < 2 || connector.y - pos.y < 2) return true;

                    var sets = new HashSet<int>(connectorRegions[pos].Select((region) => merged[region]));
                    if (sets.Count > 1) return false;

                    if (random.Next(0, 1000) < mulConnector) // 偶尔连接一下，避免地牢成为单一连通结构
                    {
                        AddJunction(field, pos.lateral, pos.radial);
                    }

                    return true;
                });

                if (connectors.Count == 0) break;
            }
        }

        /// <summary>
        /// 添加连接点
        /// </summary>
        /// <param name="field"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void AddJunction(RectangularDungeonField field, int x, int y)
        {
            field[x, y] = TileType.Path;
        }

        /// <summary>
        /// 删除死胡同
        /// </summary>
        /// <param name="field"></param>
        private void RemoveDeadEnds(RectangularDungeonField field)
        {
            var done = false;

            while (!done)
            {
                done = true;

                for (var y = 1; y < field.height-1; y++)
                {
                    for (var x = 1; x <field.width-1; x++)
                    {
                        Tile pos = new Tile(x, y);
                        if (Utils.IsWall(field, x, y)) continue;

                        var exits = 0;
                        foreach (var dir in CARDINAL_DIR)
                        {
                            var t = Find(pos, dir, 1);
                            if (!Utils.IsWall(field, t.lateral, t.radial)) exits++;
                        }

                        if (exits != 1) continue;

                        done = false;
                        field[pos.lateral, pos.radial] = TileType.Wall;
                        regions[x, y] = -1;
                    }
                }
            }
        }
    }
}