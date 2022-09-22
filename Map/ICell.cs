using System;
using CosmosStrategy.Units;

namespace CosmosStrategy.Map
{
    public interface ICell
    {
        Type GetType();
        void SetType(Type type);

        void SetGroup(Group group);
        Group GetGroup();
    }
}