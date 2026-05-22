namespace SimplexLab.Dungeon
{
    /// <summary>
    /// 
    /// </summary>
    internal static class Utils
    {
        /// <summary>
        /// 奇数
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int Odd(int value)
        {
            return (value / 2) * 2 + 1;
        }

        /// <summary>
        /// 是否为墙
        /// </summary>
        /// <param name="field"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bool IsWall(RectangularDungeonField field, int x, int y)
        {
            return field[x, y] == TileType.Wall;
        }
    }
}
