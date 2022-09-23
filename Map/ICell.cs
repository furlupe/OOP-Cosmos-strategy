using System;
using CosmosStrategy.Units;

namespace CosmosStrategy.Map
{
    public interface ICell
    {
        Type GetCellType();
        void SetCellType(Type type);

        void SetCellGroup(Group group);
        Group GetCellGroup();

        Tuple<int, int> GetCellCoords();

    }
}