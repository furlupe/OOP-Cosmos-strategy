using System;
using System.Collections.Generic;
using System.Linq;

namespace CosmosStrategy.Map
{
    internal class Map
    {
        private readonly int width;
        private readonly int height;
        private readonly ICellFactory factory;
        private readonly List<Cluster> clusters = new List<Cluster>();
        private const int MinDistanceBetween = 10;
        private readonly List<List<ICell>> map = new List<List<ICell>>();
        private readonly Random rand = new Random();
        private const int MAX_RADIUS = 30; // макс. радиус кластера
        private const int MIN_RADIUS = 5; // макс. радиус кластера
        private const double PLANET_PROBABILITY = 0.8; // вероятность появления планеты
        private const double RESOURCE_SPAWN_PROBABILITY = 0.3; // вероятность спавна ресурса на клетке



        public Map(int width, int height, ICellFactory factory)
        {
            this.width = width;
            this.height = height;
            this.factory = factory;

            for (var x = 0; x < width; x++) // заполняем карту клетками космоса
            {
                map.Add(new List<ICell>());
                for (var y = 0; y < height; y++)
                {
                    map[x].Add(factory.CreateFieldCell(
                        Group.Neutral,
                        Type.Space,
                        x,
                        y
                        ));
                }
            }

            FillWithClusters();
        }

        public ICell GetCellAt(int x, int y)
        {
            return map[x][y];
        }

        public (int, int) GetMapSize()
        {
            return (width, height);
        }

        private void FillWithClusters()
        {
            var planetsAmount = rand.Next(4, 7); // кол-во планет на карте
            while (planetsAmount > 0) // Добавление кластеров 
            {
                var x = rand.Next(MAX_RADIUS + 1, width - MAX_RADIUS - 1);
                var y = rand.Next(MAX_RADIUS + 1, height - MAX_RADIUS - 1);
                var radius = rand.Next(MIN_RADIUS, MAX_RADIUS);

                var isPlacable = true;
                foreach (var c in clusters) if (isPlacable)
                    {
                        // проверяем, если созданные координаты и радиус позволяют создать планету
                        isPlacable = DistanceBetweenСenters(c, x, y) - radius >= MinDistanceBetween + c.radius;
                    }

                if (!isPlacable) continue;
                planetsAmount--;

                var t = (rand.NextDouble() <= PLANET_PROBABILITY) ? Type.Planetary : Type.Star; // определяем тип кластера (с вер. 80% будет планета)

                var currentCluster = new Cluster(x, y, radius, t);
                clusters.Add(
                    currentCluster
                ); // добавляем кластер в список оных

                // меняем карту и присваиваем типы
                for (var cellY = -1 * radius; cellY <= radius; cellY++)
                {
                    for (var cellX = -1 * radius; cellX <= radius; cellX++)
                    {
                        var dist = DistanceBetweenСenters(currentCluster, cellX + x, cellY + y);
                        if (dist >= radius)
                        {
                            continue; // если клетка не внутри радиуса кластера - пропускаем
                        }
                        map[cellX + x][cellY + y].SetCellType(t);
                        if (t == Type.Star ||
                            rand.NextDouble() > RESOURCE_SPAWN_PROBABILITY ||
                            cellX == 0 && cellY == 0) continue;

                        AddResource(cellX + x, cellY + y); // спавним ресурс на клетке
                    }
                }
            }
        }

        private void AddResource(int x, int y)
        {
            map[x][y] = factory.CreateResourceCell(
                Group.Neutral,
                x,
                y
                );
        }

        private int DistanceBetweenСenters(Cluster clusterFst, int x, int y)
        {
            return (int)Math.Floor(
                Math.Sqrt(
                    Math.Pow(clusterFst.x - x, 2) + Math.Pow(clusterFst.y - y, 2)
                )
            );
        }
    }

}
