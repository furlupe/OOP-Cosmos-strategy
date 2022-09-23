using CosmosStrategy.Map;
using CosmosStrategy.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Type = CosmosStrategy.Map.Type;

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

        public GameManager(int mapWidth, int mapHeight)
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
            map = new Map.Map(mapWidth, mapHeight, new CellFactory());
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

            if (!CheckIfCanSpawn(id, cell))
            {
                Console.WriteLine("can't place unit");
                return;
            }
                        
            IFieldCell _cell = cell as IFieldCell;
            var unit = uf.CreateUnit(id);
            _cell.SetUnit(unit);
            unit.SetCell(_cell);

            if (unit is IDriller)
            {
                if (_cell.GetCellType() == Type.Space)
                {
                    _cell.RemoveUnit();
                    return;
                }
                var driller = unit as IDriller;
                var range = driller.GetRange();
                var (cx, cy) = _cell.GetCellCoords();
                for (int i = -range; i <= range; i++)
                {
                    for (int j = -range; j <= range; j++)
                    {
                        var c = map.GetCellAt(Math.Max(i + cx, 0), Math.Max(j + cy, 0));
                        if (c is IResourceCell)
                        {
                            driller.AddResourceCell(c as IResourceCell);
                        }
                    }
                }
                drillers.Add(driller);
            }
            SpendResources(id);
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

        public void PrintMap()
        {
            var (w, h) = map.GetMapSize();
            for (int x = 0; x < w; x++)
            {
                for (int y = 0; y < h; y++)
                {
                    char s;
                    switch (map.GetCellAt(x, y).GetCellType())
                    {
                        case Type.Planetary:
                            s = '@';
                            break;
                        case Type.Star:
                            s = '*';
                            break;
                        case Type.Space:
                            s = ' ';
                            break;
                        default:
                            s = ' ';
                            break;
                    }
                    Console.Write(s + "   ");
                }
                Console.Write('\n');
            }
        }

        private void SpendResources(int id)
        {
            foreach (var res in unitsPrices[id])
            {
                totalResources[res.Key] -= res.Value;
            }
        }

        private bool CheckIfCanSpawn(int id, ICell cell)
        {
            return (totalResources.Where(x => unitsPrices[id].Keys.Contains(x.Key))
                                .All(x => x.Value >= unitsPrices[id][x.Key])
                                && cell is IFieldCell && cell.GetCellType() != Type.Star);

        }
    }
}
