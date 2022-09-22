using System;
using System.Collections.Generic;
using System.Linq;

namespace CosmosStrategy.Map
{
    internal class Map
    {
        private int width { get; }
        private int height { get; }
        private List<Cluster> clusters = new List<Cluster>();
        private const int MinDistanceBetween = 10;
        private List<List<Cell>> map = new List<List<Cell>>();

        private const int RADIUS = 10; // макс. радиус кластера
        private const double PLANET_PROBABILITY = 0.8; // вероятность появления планеты
        private const double RESOURCE_SPAWN_PROBABILITY = 0.3; // вероятность спавна ресурса на клетке
        private const int RESOURCE_MAX_AMOUNT = 10;
        
        // верхние пределы вероятностей для каждого ресурса
        private static readonly Dictionary<Resource, double> RESOURCES_PROBABILITIES_UPPERBOUNDS = new Dictionary<Resource, double>()
        {
            {Resource.Gold, 0.16},
            {Resource.Iron, 0.32},
            {Resource.Oil, 0.48},
            {Resource.Organics, 0.64},
            {Resource.Silver, 0.80},
            {Resource.Cum, 1.00}
        };


        public Map(int width, int height)
        {
            this.width = width;
            this.height = height;

            for (var y = 0; y < height; y++) // заполняем карту клетками космоса
            {
                map.Add(new List<Cell>());
                for (var x = 0; x < width; x++)
                {
                    map[y].Add(
                        new FieldCell(
                            Group.Neutral, 
                            Type.Space,
                            new Tuple<int, int>(y, x)
                            ));
                }
            }

            FillWithClusters();
        }

        private void FillWithClusters()
        {
            var rand = new Random();
            var planetsAmount = rand.Next(4, 7); // кол-во планет на карте
            while (planetsAmount > 0) // Добавление кластеров 
            {
                var (y, x) = (rand.Next(0, height), rand.Next(0, width));
                var radius = rand.Next(3, RADIUS);
                
                var isPlacable = true;
                foreach (var c in clusters) if (isPlacable)
                {
                    // проверяем, если созданные координаты и радиус позволяют создать планету
                    isPlacable = DistanceBetweenСenters(c, y, x) - radius >= MinDistanceBetween + c.radius;
                }
                
                if (!isPlacable) continue;
                planetsAmount--;
                
                var t = (rand.NextDouble() <= PLANET_PROBABILITY) ? Type.Planetary : Type.Star; // определяем тип кластера (с вер. 80% будет планета)
                
                var currentCluster = new Cluster(y, x, radius, t);
                clusters.Add(
                    currentCluster
                ); // добавляем кластер в список оных
                
                // меняем карту и присваиваем типы
                for (var cellY = -1 * radius; cellY <= radius; cellY++)
                {
                    for (var cellX = -1 * radius; cellX <= radius; cellX++)
                    {
                        if (DistanceBetweenСenters(currentCluster, cellY + y, cellX + x) > radius) continue; // если клетка не внутри радиуса кластера - пропускаем
                        
                        map[y][x].type = t; 
                        if (t == Type.Star ||
                            rand.NextDouble() > RESOURCE_SPAWN_PROBABILITY ||
                            cellX == 0 && cellY == 0) continue;

                        AddResource(y, x); // спавним ресурс на клетке
                    }
                }
            }
        }

        private void AddResource(int y, int x)
        {
            map[y][x] = new ResourceCell(
                Group.Neutral,
                new Tuple<int, int>(y, x),
                new Tuple<Resource, int>(ChooseResource(), new Random().Next(1, RESOURCE_MAX_AMOUNT))
            );
        }

        private Resource ChooseResource()
        {
            var whichResourceProb = new Random().NextDouble();
            var prevProb = 0.0;
            var res = Resource.Gold;

            foreach (var item in RESOURCES_PROBABILITIES_UPPERBOUNDS)
            {
                if (prevProb < whichResourceProb && whichResourceProb < item.Value)
                {
                    res = item.Key;
                    break;
                }

                prevProb = item.Value;
            }

            return res;
        }

        private int DistanceBetweenСenters(Cluster clusterFst, int y, int x)
        {
            return (int) Math.Floor(
                Math.Sqrt(
                    Math.Pow(clusterFst.x - x, 2) + Math.Pow(clusterFst.y - y, 2)
                )
            );
        }
    }
    
}
