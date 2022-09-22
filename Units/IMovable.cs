using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmosStrategy.Units
{
    internal interface IMovable
    {
        List<Tuple<int, int>> Move(Tuple<int, int> coordinates);
    }
}
