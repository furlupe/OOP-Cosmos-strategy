namespace CosmosStrategy.Map
{
    public struct Cluster
    {
        public int x;
        public int y;
        public int radius;
        public Type type;

        public Cluster(int x, int y, int r, Type type)
        {
            this.x = x;
            this.y = y;
            radius = r;
            this.type = type;
        }
        
    }
}