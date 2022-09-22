using System;

namespace CosmosStrategy.Map
{
    internal abstract class Cell : ICell
    {
        protected Group group;
        protected Type type;
        protected int x;
        protected int y;
        public Cell(Group group, Type type, int x, int y)
        {
            this.group = group;
            this.type = type;
            this.x = x;
            this.y = y;
        }

        public Type GetType()
        {
            return type;
        }

        public void SetType(Type type)
        {
            this.type = type;
        }

        public void SetGroup(Group group)
        {
            this.group = group;
        }

        public Group GetGroup()
        {
            return group;
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
