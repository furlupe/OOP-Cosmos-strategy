using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CosmosStrategy.Map;
using Type = CosmosStrategy.Map.Type;

namespace CosmosStrategy.Units
{
    internal class Driller : Unit, IDriller
    {
        private int _range = 3;
        private List<IResourceCell> nearbyResourceCells;
        public Driller() : base()
        {
            nearbyResourceCells = new List<IResourceCell>();
            attackPattern = null;
            movePattern = null;
            health = 10;
        }

        public Dictionary<Resource, int> Drill()
        {
            IDictionary<Resource, int> result = new Dictionary<Resource, int>();
            foreach (var cell in nearbyResourceCells)
            {
                var r = cell.GetResource();
                if (!result.ContainsKey(r.Key))
                {
                    result.Add(r.Key, 0);
                }
                result[r.Key] += r.Value;
            }
            return result as Dictionary<Resource, int>;
        }

        public int GetRange()
        {
            return _range;
        }

        public void AddResourceCell(IResourceCell cell)
        {
            if (!nearbyResourceCells.Contains(cell))
            {
                nearbyResourceCells.Add(cell);
            }
        }
    }
}
