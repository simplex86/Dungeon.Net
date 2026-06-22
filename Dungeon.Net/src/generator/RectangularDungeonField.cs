namespace SimplexLab.Dungeon
{
    /// <summary>
    /// 
    /// </summary>
    public struct RectangularDungeonField
    {
        /// <summary>
        /// 迷宫场地的数据
        /// </summary>
        internal int[] Field = null;

        /// <summary>
        /// 宽度
        /// </summary>
        public int Width  { get; private set; } = 9;
        /// <summary>
        /// 高度
        /// </summary>
        public int Height { get; private set; } = 9;

        public RectangularDungeonField(int w, int h)
        {
            Width  = Utils.Odd(w);
            Height = Utils.Odd(h);
            
            Field = new int[Width * Height];
            for (int i=0; i<Field.Length; i++)
            {
                Field[i] = TileType.Wall;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int this[int x, int y]
        {
            get { return Field[y * Width + x]; }
            internal set { Field[y * Width + x] = value; }
        }
    }
}