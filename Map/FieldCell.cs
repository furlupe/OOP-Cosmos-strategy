using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CosmosStrategy.Units;

namespace CosmosStrategy.Map
{
    internal class FieldCell : Cell
    {
        private Unit unit;

        public FieldCell(Group group, Type type, Tuple<int, int> coordinates, Unit unit) : 
            base(group, type, coordinates)
        {
            this.unit = unit;
        }

        public void PlaceUnit(Unit unit)
        {

        }
        public void removeUnit() { }
        public Unit getUnit() { 
            return unit; 
        }
    }
}
