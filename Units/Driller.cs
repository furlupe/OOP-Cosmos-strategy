using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CosmosStrategy.Map;
using Type = CosmosStrategy.Map.Type;

namespace CosmosStrategy.Units
{
    internal class Driller : Unit, IDriller
    {
        private int _radius = 3;
        public Driller(Group group) : base()
        {
            health = 10;
        }

        public List<Tuple<Resource, int>> Drill()
        {
            throw new NotImplementedException();
        }
    }
}
