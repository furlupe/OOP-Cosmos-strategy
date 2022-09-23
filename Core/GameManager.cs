using CosmosStrategy.Map;
using CosmosStrategy.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmosStrategy.Core
{
    internal class GameManager
    {
        private Dictionary<Resource, int> totalResources = new Dictionary<Resource, int>();
        private UnitFactory uf;
        private static readonly Dictionary<int, Dictionary<Resource, int>> unitsPrices =
            new Dictionary<int, Dictionary<Resource, int>>();
        private Map.Map map;
        private List<IDriller> drillers = new List<IDriller>();
        private IUnit selectedUnit;

        public GameManager()
        {
            foreach (var item in Enum.GetValues(typeof(Resource)))
            {
                totalResources.Add((Resource)item, 80);
            }
            uf = new UnitFactory();
            /*
            * id   Unit type
            * 0    Driller
            * 1    Gunner
            * 2    Swordsman
            * 3    Turret
            */
            {
                unitsPrices.Add(0, new Dictionary<Resource, int> {
                { Resource.Iron, 10 },
                { Resource.Oil, 10 }
            });
                unitsPrices.Add(1, new Dictionary<Resource, int> {
                { Resource.Gold, 10 },
                { Resource.Cum, 1 },
                { Resource.Organics, 15 }
            });
                unitsPrices.Add(2, new Dictionary<Resource, int> {
                { Resource.Gold, 10 },
                { Resource.Silver, 15 },
                { Resource.Cum, 1 },
                { Resource.Organics, 15 }
            });
                unitsPrices.Add(3, new Dictionary<Resource, int> {
                { Resource.Iron, 20 },
                { Resource.Silver, 10 },
                { Resource.Oil, 4 },
                { Resource.Gold, 5 }
            });
            }
            map = new Map.Map(800, 600, new CellFactory());
        }

        public void AddResources()
        {
            foreach (var driller in drillers)
            {
                foreach (var res in driller.Drill())
                {
                    if (!totalResources.ContainsKey(res.Key))
                    {
                        totalResources.Add(res.Key, 0);
                    }
                    totalResources[res.Key] += res.Value;
                }
            }
        }
        public void CreateUnit(int id, int x, int y)
        {
            var cell = map.GetCellAt(x, y);
            if (!(cell is IFieldCell))
            {
                Console.WriteLine("not a field cell");
                return;
            }
            IFieldCell _cell = cell as IFieldCell;
            uf.SpawnUnit(id, _cell);
            if (_cell.GetUnit() is IDriller)
            {
                drillers.Add(_cell.GetUnit() as IDriller);
            }
        }
        public void ShowPattern(int x, int y, bool isAttack)
        {
            var cell = map.GetCellAt(x, y);
            if (!(cell is IFieldCell))
            {
                Console.WriteLine("not a field cell");
                return;
            }
            IFieldCell _cell = cell as IFieldCell;
            var unit = _cell.GetUnit();
            if (unit == null)
            {
                Console.WriteLine("no unit on the cell");
                return;
            }
            selectedUnit = unit;
            var pattern = isAttack ? unit.GetAttackPattern() : unit.GetMovePattern();
            for (int i = -3; i <= 3; i++)
            {
                for (int j = -3; j <= 3; j++)
                {
                    if (pattern[i + 3, j + 3] != 1)
                    {
                        continue;
                    }
                    var (cx, cy) = _cell.GetCellCoords();
                    Console.WriteLine($"{cx + i} {cy + j}");
                }
            }
        }

        public void AttackSelected(int targetX, int targetY)
        {
            var targetCell = (map.GetCellAt(targetX, targetY) as FieldCell);
            selectedUnit.Attack(targetCell.GetUnit());
            selectedUnit = null;
        }
        public void MoveSelected(int destX, int destY)
        {
            var destCell = (map.GetCellAt(destX, destX) as FieldCell);
            selectedUnit.Move(destCell);
            selectedUnit = null;
        }

    }
}
