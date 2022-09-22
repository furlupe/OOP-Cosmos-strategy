using System;

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

        public Tuple<Resource, int> GetResource()
        {
            return new Tuple<Resource, int> (resource, resourceAmount);
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
