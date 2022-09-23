using System;
using System.Collections.Generic;

namespace CosmosStrategy.Map
{
    public interface IResourceCell : ICell
    {
        KeyValuePair<Resource, int> GetResource();
    }
}