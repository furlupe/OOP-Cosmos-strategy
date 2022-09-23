using System;
using System.Collections.Generic;

namespace CosmosStrategy.Map
{
    public class CellFactory : ICellFactory
    {
        private const int RESOURCE_MAX_AMOUNT = 10;
        private readonly Random rand = new Random();
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

        public IResourceCell CreateResourceCell(Group group, int x, int y)
        {
            return new ResourceCell(
                group,
                x,
                y,
                ChooseResource(),
                rand.Next(1, RESOURCE_MAX_AMOUNT)
            );
        }

        public IFieldCell CreateFieldCell(Group group, Type type, int x, int y)
        {
            return new FieldCell(
                group,
                type,
                x,
                y
            );
        }

        private Resource ChooseResource()
        {
            var whichResourceProb = rand.NextDouble();
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
    }
}