using System;
using CosmosStrategy.Units;

namespace CosmosStrategy.Map
{
    internal class FieldCell : Cell, IFieldCell
    {
        private IUnit _unit;

        public FieldCell(Group group, Type type, int x, int y) :
            base(group, type, x, y)
        {
        }

        public void SetUnit(IUnit unit)
        {
            _unit = unit;
        }

        public void RemoveUnit()
        {
            SetUnit(null);
        }
        public IUnit GetUnit()
        {
            return _unit;
        }
    }
}
