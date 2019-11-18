using System.Collections.Generic;

namespace ChefLibrary.Builders
{
    using ChefLibrary.Products;
    using ChefLibrary.Products.AnimalOriginProducts;
    using ChefLibrary.Products.PlantOriginProducts;
    using System.Threading;

    public class OlivieSaladBuilder : ISaladBuilder
    {
        private Salad salad;

        public OlivieSaladBuilder()
        {
            this.Reset();
        }

        private void Reset()
        {
            salad = new Salad("Olivie", new List<Product>());
        }

        public Salad GetSalad()
        {
            Salad result = this.salad;
            Reset();

            return result;
        }

        public void AddProduct(Product product)
        {
            this.salad.AddProduct(product);
        }

        public void RemoveProduct(Product product)
        {
            this.salad.RemoveProduct(product);
        }

        public void WashProduct(IElementalProduct product)
        {
            product.Wash();
        }

        public void ChopProduct(IElementalProduct product)
        {
            product.Chop();
        }

        public void BoilProduct(IElementalProduct product)
        {
            product.Boil();
        }

        public void FryProduct(IElementalProduct product)
        {
            product.Fry();
        }

        public void BakeProduct(IElementalProduct product)
        {
            product.Bake();
        }

        public void PeelOff(PlantOriginProduct product)
        {
            product.PellOff();
        }

        public void MixProduct()
        {
            Thread.Sleep(1000);
        }
    }
}
