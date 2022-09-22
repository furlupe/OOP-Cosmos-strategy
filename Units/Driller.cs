using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using CosmosStrategy.Map;
using Type = CosmosStrategy.Map.Type;

namespace CosmosStrategy.Units
{
    internal class Driller : Unit, IDrilling
    {
        private int _radius = 3;
        public Driller(Group group, Tuple<int, int> coordinates, int radius) : base(group, coordinates)
        {
            _radius = radius;
            health = 10;
            stayCellType = Type.Planetary;
        }

        public List<Tuple<int, int>> Drill()
        {
            List<Tuple<int, int>> cellsToDig = new List<Tuple<int, int>>();
            for (int x = -_radius; x <= _radius; x++)
            {
                for (int y = -_radius; y <= _radius; y++)
                {
                    if (coordinates.Item1 + x >= 0 && coordinates.Item2 + y >= 0 && x * x + y * y < _radius)
                    {
                        cellsToDig.Add(new Tuple<int, int>(x + coordinates.Item1, y + coordinates.Item2));
                    }
                }
            }
            return cellsToDig;
        }
    }
}
