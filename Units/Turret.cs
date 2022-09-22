using CosmosStrategy.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmosStrategy.Units
{
    internal class Turret : Unit, IAttacking
    {
        public Turret(Group group, Tuple<int, int> coordinates) : base(group, coordinates)
        {
        }

        public List<Tuple<int, int>> Attack()
        {
            List<Tuple<int, int>> cellsToAttack = new List<Tuple<int, int>>();
            for (int x = -3; x <= 3; x++)
            {
                for (int y = -3; y <= 3; y++)
                {
                    if (coordinates.Item1 + x >= 0 && coordinates.Item2 + y >= 0 && Math.Max(Math.Abs(x), Math.Abs(y)) == 3)
                    {
                        cellsToAttack.Add(new Tuple<int, int>(x + coordinates.Item1, y + coordinates.Item2));
                    }
                }
            }
            return cellsToAttack;
        }
    }
}
