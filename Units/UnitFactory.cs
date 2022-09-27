using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CosmosStrategy.Map;

namespace CosmosStrategy.Units
{
    internal class UnitFactory
    {
        /*
         * id   Unit type
         * 0    Driller
         * 1    Gunner
         * 2    Swordsman
         * 3    Turret
         */
        //Передается только юнит, который может быть поставлен на свою клетку
        public IUnit CreateUnit(int id)
        {
            return id switch
            {
                0 => new Driller(),
                1 => new Gunner(),
                2 => new Swordsman(),
                3 => new Turret(),
                _ => throw new Exception("Incorrect Unit ID")
            };
        }
    }
}
