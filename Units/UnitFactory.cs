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
        public void SpawnUnit(int id, IFieldCell cell)
        {
            switch (id)
            {
                case 0:
                    throw new Exception("No nearby cells were given. Driller must have nearby cells");
                case 1:
                    cell.SetUnit(new Gunner(cell));
                    break;
                case 2:
                    cell.SetUnit(new Swordsman(cell));
                    break;
                case 3:
                    cell.SetUnit(new Turret(cell));
                    break;
                default:
                    throw new Exception("Incorrect Unit ID");

            }
        }

        public void SpawnUnit(int id, IFieldCell cell, List<ICell> cells)
        {
            switch (id)
            {
                case 0:
                    cell.SetUnit(new Driller(cell, cells));
                    break;
                default:
                    throw new Exception("Not a driller in ID field");
            }
        }
    }
}
