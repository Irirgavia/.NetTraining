namespace ChefLibrary.Products.PlantOriginProducts
{
    public class Vegetable : PlantOriginProduct
    {
        public Vegetable(
            string name,
            double weight,
            Caloricity caloricity,
            Conditions condition)
            : base(name, weight, caloricity, condition)
        {
        }

        public override void Boil()
        {
            this.Conditions = Conditions.Boil;
            this.Caloricity.Proteins -= Constants.VegetableBoilingLossPercentage * this.Caloricity.Proteins;
            this.Caloricity.Fats -= Constants.VegetableBoilingLossPercentage * this.Caloricity.Fats;
            this.Caloricity.Carbohydrates -= Constants.VegetableBoilingLossPercentage * this.Caloricity.Carbohydrates;
        }

        public override void Fry()
        {
            this.Conditions = Conditions.Fry;
            this.Caloricity.Proteins -= Constants.VegetableFryingLossPercentage * this.Caloricity.Proteins;
            this.Caloricity.Fats -= Constants.VegetableFryingLossPercentage * this.Caloricity.Fats;
            this.Caloricity.Carbohydrates -= Constants.VegetableFryingLossPercentage * this.Caloricity.Carbohydrates;
        }

        public override void Bake()
        {
            this.Conditions = Conditions.Bake;
            this.Caloricity.Proteins -= Constants.VegetableBakingLossPercentage * this.Caloricity.Proteins;
            this.Caloricity.Fats -= Constants.VegetableBakingLossPercentage * this.Caloricity.Fats;
            this.Caloricity.Carbohydrates -= Constants.VegetableBakingLossPercentage * this.Caloricity.Carbohydrates;
        }
    }
}
