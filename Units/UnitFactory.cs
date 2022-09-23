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
            switch (id)
            {
                case 0:
                    return new Driller();
                case 1:
                    return new Gunner();
                case 2:
                    return new Swordsman();
                case 3:
                    return new Turret();
                default:
                    throw new Exception("Incorrect Unit ID");
            }
        }
    }
}
