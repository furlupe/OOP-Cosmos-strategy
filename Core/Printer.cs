using System;
using CosmosStrategy.Map;
using Type = CosmosStrategy.Map.Type;

namespace CosmosStrategy.Core
{
    public static class Printer
    {
        public static void PrintError(string error)
        {
            Console.WriteLine($"Error: {error}");
        }
        public static void ShowPattern(IFieldCell cell, bool isAttack)
        {
            var unit = cell.GetUnit();

            var pattern = isAttack ? unit.GetAttackPattern() : unit.GetMovePattern();
            for (var i = -3; i <= 3; i++)
            {
                for (var j = -3; j <= 3; j++)
                {
                    if (pattern[i + 3, j + 3] != 1)
                    {
                        continue;
                    }
                    var (cx, cy) = cell.GetCellCoords();
                    Console.WriteLine($"{cx + i} {cy + j}");
                }
            }
        }
        
        public static void PrintMap(ref Map.Map map)
        {
            var (w, h) = map.GetMapSize();
            for (var x = 0; x < w; x++)
            {
                for (var y = 0; y < h; y++)
                {
                    var s = map.GetCellAt(x, y).GetCellType() switch
                    {
                        Type.Planetary => '@',
                        Type.Star => '*',
                        Type.Space => ' ',
                        _ => ' '
                    };
                    Console.Write(s + "   ");
                }
                Console.Write('\n');
            }
        }
        
    }
}