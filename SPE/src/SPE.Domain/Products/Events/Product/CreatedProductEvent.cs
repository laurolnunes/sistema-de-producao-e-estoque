namespace SPE.Domain.Products.Events.Product
{
    public class CreatedProductEvent : BaseProductEvent
    {
        public CreatedProductEvent(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
            AggregateId = id;
        }
    }
}