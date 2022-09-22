using CosmosStrategy.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmosStrategy.Units
{
    internal class Turret : Unit, IAttacking
    {
        public Turret(Group group, Tuple<int, int> coordinates) : base(group, coordinates)
        {
        }

        public List<Tuple<int, int>> Attack(Tuple<int, int> coordinates)
        {
            throw new NotImplementedException();
        }
    }
}
