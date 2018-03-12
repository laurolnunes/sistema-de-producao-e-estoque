namespace SPE.Domain.Products.Events.Brand
{
    public class UpdatedBrandEvent : BaseBrandEvent
    {
        public UpdatedBrandEvent(int id, string name)
        {
            Id = id;
            Name = name;
            AggregateId = Id;
        }
    }
}