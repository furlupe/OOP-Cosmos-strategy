using System.Collections.Generic;
using CosmosStrategy.Map;

namespace CosmosStrategy.Units
{
    public interface IUnit
    {
        void Attack(IUnit target);
        void Move(IFieldCell destination);
        void TakeDamage(double damage);
        void SetCell(IFieldCell cell);
        void Die();

        int[,] GetMovePattern();
        int[,] GetAttackPattern();
    }
}