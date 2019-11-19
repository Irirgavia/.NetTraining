namespace ChefLibrary.Builders
{
    using ChefLibrary.Products;

    public interface ISaladBuilder
    {
        ISalad GetSalad();

        void BuildSalad();

        void AddProduct(IProduct product);

        void RemoveProduct(IProduct product);

        void MixSalad();
    }
}
