namespace DemoLog.Dmoain.OrderAgg.Base
{
    public class BaseEntity
    {
        public int Id { get;protected set; }
        public DateTime CratedAt { get; protected set; }
        public bool IsDeleted { get; protected set; }
        public string Name { get; protected set; }

    }
}
