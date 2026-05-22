using System;
using SimplexLab.Dungeon;

namespace Dungeon.TConsole
{
    class TDungeon
    {
        private RectangularDungeonGenerator dungeon = new RectangularDungeonGenerator();

        public void Run()
        {
            var width = Console.WindowWidth - 1;
            var height = Console.WindowHeight - 3;
            var minRoomWidth = 3;
            var maxRoomWidth = 9;
            var minRoomHeight = 3;
            var maxRoomHeight = 9;
            var maxRoomCount = 20;
            var mulConnector = 3;

            var field = dungeon.Create(width, height, minRoomWidth, maxRoomWidth, minRoomHeight, maxRoomHeight, maxRoomCount, mulConnector, 25);
            Show(field);
        }

        private void Show(RectangularDungeonField field)
        {
            var text = "";
            for (int y = 0; y < field.height; y++)
            {
                for (int x = 0; x < field.width; x++)
                {
                    text += (field[x, y] == TileType.Path) ? " " : "█";
                }
                text += "\n";
            }

            Console.Write(text);
        }
    }
}