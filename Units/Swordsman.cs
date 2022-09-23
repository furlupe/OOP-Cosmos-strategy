using CosmosStrategy.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmosStrategy.Units
{
    internal class Swordsman : Unit
    {
        public Swordsman() : base()
        {
            health = 7;
            damage = 5;
            attackPattern = new int[7, 7]
            {
                {0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0},
                {0,0,1,1,1,0,0},
                {0,0,1,0,1,0,0},
                {0,0,1,1,1,0,0},
                {0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0}
            };
            movePattern = new int[7, 7]
            {
                {0,0,0,0,0,0,0},
                {0,0,0,1,0,0,0},
                {0,0,1,1,1,0,0},
                {0,1,1,0,1,1,0},
                {0,0,1,1,1,0,0},
                {0,0,0,1,0,0,0},
                {0,0,0,0,0,0,0}
            };
        }
    }
}
