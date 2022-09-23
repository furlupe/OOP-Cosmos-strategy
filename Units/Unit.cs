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

        public Unit()
        {
        }

        public void Attack(IUnit target)
        {
            if (target == null)
            {
                Console.WriteLine("No target on this cell");
            }
            target.TakeDamage(damage);
        }

        public void Move(IFieldCell destination)
        {
            if (destination.GetCellType() == Type.Star) return;
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

        public void SetCell(IFieldCell cell)
        {
            currentCell = cell;
        }
    }
}
