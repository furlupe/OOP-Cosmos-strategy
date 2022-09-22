namespace CosmosStrategy.Map
{
    public class CellFactory : ICellFactory
    {
        public IResourceCell CreateResourceCell(Group group, int y, int x, Resource resource, int resourceAmount)
        {
            return new ResourceCell(
                group,
                y,
                x,
                resource,
                resourceAmount
            );
        }

        public IFieldCell CreateFieldCell(Group group, Type type, int y, int x)
        {
            return new FieldCell(
                group,
                type,
                y,
                x
            );
        }
    }
}