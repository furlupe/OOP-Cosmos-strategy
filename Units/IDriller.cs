using System;
using System.Collections.Generic;
using CosmosStrategy.Map;

namespace CosmosStrategy.Units
{
    public interface IDriller : IUnit
    {
        List<Tuple<Resource, int>> Drill();
    }
}