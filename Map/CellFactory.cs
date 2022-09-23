namespace CosmosStrategy.Map
{
    public class CellFactory : ICellFactory
    {
        public IResourceCell CreateResourceCell(Group group, int x, int y, Resource resource, int resourceAmount)
        {
            return new ResourceCell(
                group,
                x,
                y,
                resource,
                resourceAmount
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
    }
}