using System.Collections.Generic;
using CosmosStrategy.Map;

namespace CosmosStrategy.Units
{
    public interface IUnit
    {
        void Attack(IUnit target);
        void Move(IFieldCell destination);
        void TakeDamage(double damage);
        void Die();

        List<List<bool>> GetMovePattern();
        List<List<bool>> GetAttackPattern();
    }
}