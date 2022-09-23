using System;
using System.Collections.Generic;
using CosmosStrategy.Map;

namespace CosmosStrategy.Units
{
    public interface IDriller : IUnit
    {
        Dictionary<Resource, int> Drill();
        int GetRange();
        void AddResourceCell(IResourceCell cell);
    }
}