using System.Collections.Generic;

namespace AdventureWorks.Services.Production
{
    public interface IProductService
    {
        ICollection<Product> GetProducts();

        Product GetProduct(int productId);

        void CreateProduct(Product productToCreate);

        bool UpdateProduct(Product updatedProduct);

        bool DeleteProduct(int productId);
    }
}
