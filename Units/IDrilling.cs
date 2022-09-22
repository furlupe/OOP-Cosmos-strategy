using CosmosStrategy.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmosStrategy.Units
{
    internal interface IDrilling
    {
        List<Tuple<Resource, int>> Drill(Tuple<int, int> coordinates);
    }
}
