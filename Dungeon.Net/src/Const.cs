namespace SimplexLab.Dungeon
{
    /// <summary>
    /// 矩形地牢算法
    /// </summary>
    public enum DungeonAlgorithm
    {
        /// <summary>
        /// 
        /// </summary>
        Nystroms = 1,
        /// <summary>
        /// 由 Nystroms 改进的算法，生成异形房间
        /// </summary>
        OverlapR = 2,
    }

    /// <summary>
    /// 地块类型
    /// </summary>
    public static class TileType
    {
        /// <summary>
        /// 墙
        /// </summary>
        public const int Wall  = 0;
        /// <summary>
        /// 通路
        /// </summary>
        public const int Path  = 1;
    }
}