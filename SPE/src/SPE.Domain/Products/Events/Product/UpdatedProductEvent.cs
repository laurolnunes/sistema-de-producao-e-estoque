namespace SPE.Domain.Products.Events.Product
{
    public class UpdatedProductEvent : BaseProductEvent
    {
        public UpdatedProductEvent(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
            AggregateId = id;
        }
    }
}