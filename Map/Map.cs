using System;
using System.Collections.Generic;

namespace CosmosStrategy.Map
{
    internal class Map
    {
        private int width;
        private int height;
        private List<Cluster> clusters;
        private const int MinDistanceBetween = 10;
        private List<List<Cell>> map;

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
            var (x, y) = center;
            clusters.Add(
                new Cluster (
                    x, 
                    y, 
                    radius, 
                    type
                    )
            );
        }

        private int DistanceBetween(Cluster clusterFst, Cluster clusterSnd)
        {
            return (int) Math.Floor(
                Math.Sqrt(
                    Math.Pow(clusterFst.x - clusterSnd.y, 2) + Math.Pow(clusterFst.x - clusterSnd.y, 2)
                )
            );
        }
    }
    
}
