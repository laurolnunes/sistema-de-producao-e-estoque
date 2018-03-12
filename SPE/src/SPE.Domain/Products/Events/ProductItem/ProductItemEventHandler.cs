using SPE.Domain.Core.Events;

namespace SPE.Domain.Products.Events.ProductItem
{
    public class ProductItemEventHandler :
        IHandler<CreatedProductItemEvent>,
        IHandler<UpdatedProductItemEvent>,
        IHandler<DeletedProductItemEvent>
    {
        public void Handle(CreatedProductItemEvent message)
        {
            // Enviar um e-mail ou fazer log
        }

        public void Handle(UpdatedProductItemEvent message)
        {
            // Enviar um e-mail ou fazer log
        }

        public void Handle(DeletedProductItemEvent message)
        {
            // Enviar um e-mail ou fazer log
        }
    }
}