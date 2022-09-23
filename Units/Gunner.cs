using CosmosStrategy.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmosStrategy.Units
{
    internal class Gunner : Unit
    {
        public Gunner() : base()
        {
            health = 10;
            damage = 2;
            attackPattern = new int[7, 7]
            {
                {0,0,0,1,0,0,0},
                {0,0,1,1,1,0,0},
                {0,1,1,0,1,1,0},
                {1,1,0,0,0,1,1},
                {0,1,1,0,1,1,0},
                {0,0,1,1,1,0,0},
                {0,0,0,1,0,0,0}
            };
            movePattern = new int[7, 7]
            {
                {0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0},
                {0,0,0,1,0,0,0},
                {0,0,1,0,1,0,0},
                {0,0,0,1,0,0,0},
                {0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0}
            };
        }
    }
}
