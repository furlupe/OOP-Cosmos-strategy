using System;
using System.Collections.Generic;
using Resource = CosmosStrategy.Map.Resource;
using CosmosStrategy.Map;

namespace CosmosStrategy.Units
{
    public interface IDriller : IUnit
    {
        Dictionary<Resource, int> Drill();
        int GetRange();
        void GetResourceCellsFromRange(ref Map.Map map);
    }
}