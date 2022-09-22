using System;
using CosmosStrategy.Map;
using Type = CosmosStrategy.Map.Type;

namespace CosmosStrategy.Units
{
    internal abstract class Unit
    {
        private int health { get; set; }
        public Type stayCellType { get; set; }
        private Group group { get; set; }
        public Tuple<int, int> coordinates { get; set; }

        protected Unit(Group group, Tuple<int, int> coordinates)
        {
            this.group = group;
            this.coordinates = coordinates;
        }
    }
}
