using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmosStrategy.Map
{
    internal class Map
    {
        private int width;
        private int height;
        private List<Cluster> clusters;
        private const int MinDistanceBetween = 10;

        public Map(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public void AddResources()
        {
            
        }

        private void CreateCluster(Tuple<int, int> center, int radius, Type type)
        {
        }

        private int DistanceBetween(Cluster clusterFst, Cluster clusterSnd)
        {
            return (int) Math.Floor(
                Math.Sqrt(
                    Math.Pow(clusterFst.X - clusterSnd.X, 2) + Math.Pow(clusterFst.Y - clusterSnd.Y, 2)
                )
            );
        }
    }
    
}
