using SPE.Domain.Core.Events;

namespace SPE.Domain.Products.Events.Product
{
    public class ProductEventHandler :
        IHandler<CreatedProductEvent>,
        IHandler<UpdatedProductEvent>,
        IHandler<DeletedProductEvent>
    {
        public void Handle(CreatedProductEvent message)
        {
            // Enviar um e-mail ou fazer log
        }

        public void Handle(UpdatedProductEvent message)
        {
            // Enviar um e-mail ou fazer log
        }

        public void Handle(DeletedProductEvent message)
        {
            // Enviar um e-mail ou fazer log
        }
    }
}