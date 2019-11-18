namespace ChefLibrary.Builders
{
    using ChefLibrary.Products;

    public interface ISaladBuilder
    {
        Salad GetSalad();

        void AddProduct(Product product);

        void RemoveProduct(Product product);

        void MixProduct();
    }
}
