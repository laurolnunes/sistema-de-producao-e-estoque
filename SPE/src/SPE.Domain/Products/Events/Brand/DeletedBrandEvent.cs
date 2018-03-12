namespace SPE.Domain.Products.Events.Brand
{
    public class DeletedBrandEvent : BaseBrandEvent
    {
        public DeletedBrandEvent(int id)
        {
            Id = id;
            AggregateId = id;
        }
    }
}