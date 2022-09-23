using CosmosStrategy.Units;

namespace CosmosStrategy.Map
{
    public interface IFieldCell : ICell
    {
        void SetUnit(IUnit unit);
        void RemoveUnit();
        IUnit GetUnit();
    }
}