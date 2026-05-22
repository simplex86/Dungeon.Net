// See https://aka.ms/new-console-template for more information
using System;
using Dungeon.TConsole;

while (true)
{
    var dungeon = new TDungeon();
    dungeon.Run();

    Console.Write("\n任意键刷新，ESC退出！");

    var key = Console.ReadKey();
    if (key.Key == ConsoleKey.Escape) break;

    Console.Clear();
}