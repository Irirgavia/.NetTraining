namespace ChefLibrary
{
    using System.Collections.Generic;

    using ChefLibrary.Products;

    public interface ISalad
    {
        List<Product> GetAllProducts();

        void AddProduct(Product product);

        void RemoveProduct(Product product);
    }
}
