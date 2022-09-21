using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CosmosStrategy.Map;
using Type = CosmosStrategy.Map.Type;

namespace CosmosStrategy.Units
{
    internal class Driller : Unit
    {
        private int _radius = 3;
        public Driller(Group group) : base(group)
        {
            health = 10;
            stayCellType = Type.Planetary;
        }
    }
}
