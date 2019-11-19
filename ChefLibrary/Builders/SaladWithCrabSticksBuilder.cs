namespace ChefLibrary.Builders
{
    using System.Security;

    using ChefLibrary.Products;
    using ChefLibrary.Products.AnimalOriginProducts;

    public class SaladWithCrabSticksBuilder : SaladBuilder
    {
        public SaladWithCrabSticksBuilder()
            : base("Salad with crab sticks")
        {
            this.Reset(this.Salad.Name);
        }

        public override void BuildSalad()
        {
            this.AddProduct(this.GetPeelOffBoilChopEgg(165));
            this.AddProduct(this.GetRawCucumber(100));
            this.AddProduct(this.GetChopCrabSticks(200));
            this.AddProduct(this.GetMayonnaise(50));
        }

        public Meat GetChopCrabSticks(double weight)
        {
            var crabSticks = new Meat(
                "Crab Sticks",
                weight,
                new Caloricity(12, 2, 20),
                "crab",
                Conditions.Raw);

            this.ChopProduct(crabSticks);
            return crabSticks;
        }
    }
}
