namespace CosmosStrategy.Map
{
    public interface ICellFactory
    {
        IResourceCell CreateResourceCell(Group group, int y, int x, Resource resource, int resourceAmount);
        IFieldCell CreateFieldCell(Group group, Type type, int y, int x);
    }
}