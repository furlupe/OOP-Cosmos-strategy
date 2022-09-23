using CosmosStrategy.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmosStrategy.Units
{
    internal class Turret : Unit
    {
        public Turret(IFieldCell cell) : base(cell)
        {
            health = 15;
            damage = 4;
            attackPattern = new int[7, 7]
            {
                {1,1,1,1,1,1,1},
                {1,1,1,1,1,1,1},
                {1,1,0,0,0,1,1},
                {1,1,0,0,0,1,1},
                {1,1,0,0,0,1,1},
                {1,1,1,1,1,1,1},
                {1,1,1,1,1,1,1}
            };
            movePattern = null;
        }
    }
}
