using CosmosStrategy.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmosStrategy.Units
{
    internal class Gunner : Unit, IMovable, IAttacking
    {
        public Gunner(Group group, Tuple<int, int> coordinates) : base(group, coordinates)
        {
            health = 10;
        }

        public List<Tuple<int, int>> Attack()
        {
            List<Tuple<int, int>> cellsToAttack = new List<Tuple<int, int>>();
            for (int x = -3; x <= 3; x++)
            {
                for (int y = -3; y <= 3; y++)
                {
                    if (coordinates.Item1 + x >= 0 && coordinates.Item2 + y >= 0 && x * x + y * y >= 8 && x * x + y * y <= 9)
                    {
                        cellsToAttack.Add(new Tuple<int, int>(x + coordinates.Item1, y + coordinates.Item2));
                    }
                }
            }
            return cellsToAttack;
        }

        public List<Tuple<int, int>> Move()
        {
            List<Tuple<int, int>> cellsToMove = new List<Tuple<int, int>>();
            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    if (coordinates.Item1 + x >= 0 && coordinates.Item2 + y >= 0 && (y != 0 || x != 0))
                    {
                        cellsToMove.Add(new Tuple<int, int>(x + coordinates.Item1, y + coordinates.Item2));
                    }
                }
            }
            return cellsToMove;
        }
    }
}
