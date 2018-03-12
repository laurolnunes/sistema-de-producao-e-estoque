using SPE.Domain.Core.Events;

namespace SPE.Domain.Products.Events.Brand
{
    public class BrandEventHandler :
        IHandler<CreatedBrandEvent>,
        IHandler<UpdatedBrandEvent>,
        IHandler<DeletedBrandEvent>
    {
        public void Handle(CreatedBrandEvent message)
        {
            // Enviar um e-mail ou fazer log
        }

        public void Handle(UpdatedBrandEvent message)
        {
            // Enviar um e-mail ou fazer log
        }

        public void Handle(DeletedBrandEvent message)
        {
            // Enviar um e-mail ou fazer log
        }
    }
}