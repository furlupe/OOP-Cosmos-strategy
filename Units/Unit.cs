using System;
using System.Collections.Generic;
using CosmosStrategy.Map;
using Type = CosmosStrategy.Map.Type;

namespace CosmosStrategy.Units
{
    public abstract class Unit : IUnit
    {
        private IFieldCell currentCell;
        protected double damage;
        protected double health;

        protected int[,] movePattern;
        protected int[,] attackPattern;

        public Unit(IFieldCell cell)
        {
            currentCell = cell;
        }

        public void Attack(IUnit target)
        {
            target.TakeDamage(damage);
        }

        public void Move(IFieldCell destination)
        {
            currentCell.RemoveUnit();
            currentCell = destination;
        }

        public void TakeDamage(double damageTaken)
        {
            health -= damageTaken;
            if (health < 0) Die();
        }

        public void Die()
        {
            currentCell.RemoveUnit();
        }

        public int[,] GetMovePattern()
        {
            return movePattern;
        }

        public int[,] GetAttackPattern()
        {
            return attackPattern;
        }
    }
}
