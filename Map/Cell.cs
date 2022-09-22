using System;

namespace CosmosStrategy.Map
{
    internal abstract class Cell
    {
        protected Group group { get; set; }
        public Type type;
        protected Tuple<int, int> coordinates { get; }
        public Cell(Group group, Type type, Tuple<int, int> coordinates)
        {
            this.group = group;
            this.type = type;
            this.coordinates = coordinates;
        }

    }

    public enum Group
    {
        Player,
        Enemy,
        Neutral
    }

    public enum Type
    {
        Planetary,
        Space,
        Star
    }
}
