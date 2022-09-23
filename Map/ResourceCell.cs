using System;
using System.Collections.Generic;

namespace CosmosStrategy.Map
{
    internal class ResourceCell : Cell, IResourceCell
    {
        private Resource resource;
        private int resourceAmount;

        public ResourceCell(Group group, int x, int y, Resource resource, int resourceAmount) :
            base(group, Type.Planetary, x, y)
        {
            this.resource = resource;
            this.resourceAmount = resourceAmount;
        }

        public KeyValuePair<Resource, int> GetResource()
        {
            return new KeyValuePair<Resource, int>(resource, resourceAmount);
        }

    }

    public enum Resource
    {
        Gold,
        Iron,
        Silver,
        Organics,
        Oil,
        Cum
    }
}
