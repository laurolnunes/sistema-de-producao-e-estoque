using SPE.Domain.Core.Commands;

namespace SPE.Domain.Products.Commands.ProductItem
{
    public class BaseProductItemCommand : Command
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int ProductItemId { get; set; }

        public int Units { get; set; }
    }
}