using System;
using CosmosStrategy.Map;
using Type = CosmosStrategy.Map.Type;

namespace CosmosStrategy.Units
{
    internal abstract class Unit
    {
        public Tuple<int, int> coordinates { get; set; }
        public Type stayCellType { get; set; }

        protected int health { get; set; }
        protected Group group { get; set; }

        protected Unit(Group group)
        {
            this.group = group;
        }
    }
}
