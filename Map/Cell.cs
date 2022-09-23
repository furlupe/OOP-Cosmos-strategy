using CosmosStrategy.Units;
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

        public Type GetCellType()
        {
            return type;
        }

        public void SetCellType(Type type)
        {
            this.type = type;
        }

        public void SetCellGroup(Group group)
        {
            this.group = group;
        }

        public Group GetCellGroup()
        {
            return group;
        }

        public Tuple<int, int> GetCellCoords()
        {
            return new Tuple<int, int>(x, y);
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
