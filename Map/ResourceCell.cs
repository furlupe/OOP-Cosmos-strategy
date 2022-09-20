using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CosmosStrategy.Units;

namespace CosmosStrategy.Map
{
    internal class ResourceCell : Cell
    {
        private Tuple<Resource, int> resourse { get; }

        public ResourceCell(Group @group, Type type, Tuple<int, int> coordinates, Tuple<Resource, int> resource) : 
            base(@group, type, coordinates)
        {
            this.resourse = resource;
        }
    }
    
    enum Resource
    {
        Gold,
        Iron,
        Silver,
        Organics,
        Oil,
        Cum
    }
}
