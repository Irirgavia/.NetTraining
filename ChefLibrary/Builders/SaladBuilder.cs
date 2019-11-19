namespace ChefLibrary.Builders
{
    using System.Collections.Generic;
    using System.Threading;

    using ChefLibrary.Products;
    using ChefLibrary.Products.AnimalOriginProducts;
    using ChefLibrary.Products.MixedProducts;
    using ChefLibrary.Products.PlantOriginProducts;

    public abstract class SaladBuilder : ISaladBuilder
    {
        protected SaladBuilder(string nameSalad)
        {
            this.Salad = new Salad(nameSalad, new List<IProduct>());
        }

        protected ISalad Salad { get; set; }

        public abstract void BuildSalad();

        public ISalad GetSalad()
        {
            this.BuildSalad();
            this.MixSalad();
            var result = this.Salad;
            this.Reset(this.Salad.Name);

            return result;
        }

        public void AddProduct(IProduct product)
        {
            this.Salad.AddProduct(product);
        }

        public void RemoveProduct(IProduct product)
        {
            this.Salad.RemoveProduct(product);
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
            product.PeelOff();
        }

        public void SkinOff(AnimalOriginProduct product)
        {
            product.SkinOff();
        }

        public void MixSalad()
        {
            Thread.Sleep(1000);
        }

        public Sauce GetMayonnaise(double weight)
        {
            var mayonnaise = new Sauce(
                "mayonnaise",
                weight,
                new Caloricity(4.8, 134, 7.8),
                SauceСonsistency.MediumDensity);

            return mayonnaise;
        }

        public Egg GetPeelOffBoilChopEgg(double weight)
        {
            var egg = new Egg(
               "egg",
               weight,
               new Caloricity(34.93, 29.98, 1.9),
               "chicken",
               Conditions.Raw);

            this.BoilProduct(egg);
            this.SkinOff(egg);
            this.ChopProduct(egg);
            return egg;
        }

        public Vegetable GetRawCucumber(double weight)
        {
            var cucumber = new Vegetable(
                "cucumber",
                weight,
                new Caloricity(0.8, 0.1, 2.8),
                Conditions.Boil);

            this.ChopProduct(cucumber);
            return cucumber;
        }

        protected void Reset(string nameSalad)
        {
            this.Salad = new Salad(nameSalad, new List<IProduct>());
        }
    }
}
