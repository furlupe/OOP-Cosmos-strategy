using System;
using CosmosStrategy.Units;

namespace CosmosStrategy.Map
{
    internal class FieldCell : Cell
    {
        private Unit _unit;

        public FieldCell(Group group, Type type, Tuple<int, int> coordinates) :
            base(group, type, coordinates)
        {
        }

        public bool PlaceUnit(Unit newUnit)
        {
            if (newUnit.stayCellType != type) return false;
            newUnit.coordinates = coordinates;
            _unit = newUnit;
            return true;
        }

        public void RemoveUnit()
        {
            _unit = null;
        }
        public Unit GetUnit() { 
            return _unit; 
        }
    }
}
