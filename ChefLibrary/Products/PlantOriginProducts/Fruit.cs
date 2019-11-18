namespace ChefLibrary.Products.PlantOriginProducts
{
    public class Fruit : PlantOriginProduct
    {
        public Fruit(
            string name,
            double weight,
            Caloricity caloricity,
            Constants.Conditions condition)
            : base(name, weight, caloricity, condition)
        {
        }

        public override void Boil()
        {
            this.Conditions = Constants.Conditions.Boil;
            this.Caloricity.Proteins -= Constants.FruitBoilingLossPercentage * this.Caloricity.Proteins;
            this.Caloricity.Fats -= Constants.FruitBoilingLossPercentage * this.Caloricity.Fats;
            this.Caloricity.Carbohydrates -= Constants.FruitBoilingLossPercentage * this.Caloricity.Carbohydrates;
        }

        public override void Fry()
        {
            this.Conditions = Constants.Conditions.Fry;
            this.Caloricity.Proteins -= Constants.FruitFryingLossPercentage * this.Caloricity.Proteins;
            this.Caloricity.Fats -= Constants.FruitFryingLossPercentage * this.Caloricity.Fats;
            this.Caloricity.Carbohydrates -= Constants.FruitFryingLossPercentage * this.Caloricity.Carbohydrates;
        }

        public override void Bake()
        {
            this.Conditions = Constants.Conditions.Bake;
            this.Caloricity.Proteins -= Constants.FruitBakingLossPercentage * this.Caloricity.Proteins;
            this.Caloricity.Fats -= Constants.FruitBakingLossPercentage * this.Caloricity.Fats;
            this.Caloricity.Carbohydrates -= Constants.FruitBakingLossPercentage * this.Caloricity.Carbohydrates;
        }

        public override string ToString()
        {
            return $"{base.ToString()} ";
        }
    }
}
