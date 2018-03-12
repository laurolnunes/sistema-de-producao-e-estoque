namespace SPE.Domain.Products.Events.Brand
{
    public class CreatedBrandEvent : BaseBrandEvent
    {
        public CreatedBrandEvent(int id, string name)
        {
            Id = id;
            Name = name;
            AggregateId = id;
        }
    }
}