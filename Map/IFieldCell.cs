using CosmosStrategy.Units;

namespace CosmosStrategy.Map
{
    public interface IFieldCell : ICell
    {
        void SetUnit(Unit unit);
        void RemoveUnit();
        IUnit GetUnit();
    }
}