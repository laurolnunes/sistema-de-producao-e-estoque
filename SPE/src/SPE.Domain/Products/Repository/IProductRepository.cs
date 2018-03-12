using System.Collections.Generic;
using SPE.Domain.Interfaces;

namespace SPE.Domain.Products.Repository
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> GetCompositionItems(int id);

        // Stock

        void AddStock(Stock obj);

        void UpdateStock(Stock obj);

        void RemoveStock(int idStock);

        Stock GetStockById(int idStock);

        IEnumerable<Stock> GetStockByProductId(int idProduct);

        // Brand

        void AddBrand(Brand obj);

        void UpdateBrand(Brand obj);

        void RemoveBrand(int idBrand);

        Brand GetBrandById(int idBrand);

        IEnumerable<Brand> GetBrandByProductId(int idProduct);

        // Product Item

        void AddProductItem(ProductItem obj);

        void UpdateProductItem(ProductItem obj);

        void RemoveProductItem(int idProductItem);

        ProductItem GetProductItemById(int idProductItem);

        IEnumerable<ProductItem> GetProductItemByProductId(int idProduct);
    }
}