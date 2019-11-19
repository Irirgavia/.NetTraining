namespace ChefLibrary.Builders
{
    using ChefLibrary.Products;
    using ChefLibrary.Products.AnimalOriginProducts;
    using ChefLibrary.Products.PlantOriginProducts;

    public class OlivierSaladBuilder : SaladBuilder
    {
        public OlivierSaladBuilder()
            : base("Olivier")
        {
            this.Reset(this.Salad.Name);
        }

        public override void BuildSalad()
        {
            this.AddProduct(this.GetChopSausage(300));
            this.AddProduct(this.GetPeelOffBoilChopPotato(500));
            this.AddProduct(this.GetPeelOffBoilChopEgg(275));
            this.AddProduct(this.GetRawCucumber(400));
            this.AddProduct(this.GetMayonnaise(200));
        }

        public Vegetable GetPeelOffBoilChopPotato(double weight)
        {
            var potato = new Vegetable(
                "potato",
                weight,
                new Caloricity(10, 2, 90.5),
                Conditions.Raw);

            this.BoilProduct(potato);
            this.PeelOff(potato);
            this.ChopProduct(potato);
            return potato;
        }

        public Meat GetChopSausage(double weight)
        {
            var sausage = new Meat(
                "sausage",
                weight,
                new Caloricity(38.4, 66.6, 4.5),
                "pork",
                Conditions.Boil);

            this.ChopProduct(sausage);
            return sausage;
        }
    }
}
