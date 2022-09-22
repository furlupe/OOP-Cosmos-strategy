using System;

namespace CosmosStrategy.Map
{
    public interface IResourceCell : ICell
    {
        Tuple<Resource, int> GetResource();
    }
}