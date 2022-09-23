namespace CosmosStrategy.Map
{
    public interface ICellFactory
    {
        IResourceCell CreateResourceCell(Group group, int x, int y);
        IFieldCell CreateFieldCell(Group group, Type type, int x, int y);
    }
}