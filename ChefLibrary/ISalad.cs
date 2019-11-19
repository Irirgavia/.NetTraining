namespace ChefLibrary
{
    using System.Collections.Generic;

    using ChefLibrary.Products;

    public interface ISalad
    {
        string Name { get; }

        List<IProduct> Products { get; }

        void AddProduct(IProduct product);

        void RemoveProduct(IProduct product);
    }
}
