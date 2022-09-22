using System;
using CosmosStrategy.Map;
using Type = CosmosStrategy.Map.Type;

namespace CosmosStrategy.Units
{
    internal abstract class Unit
    {
        public int health = 10;
        public Type stayCellType { get; set; }
        public Group group { get; protected set; }
        public Tuple<int, int> coordinates { get; set; }

        protected Unit(Group group, Tuple<int, int> coordinates)
        {
            this.group = group;
            this.coordinates = coordinates;
        }
    }
}
