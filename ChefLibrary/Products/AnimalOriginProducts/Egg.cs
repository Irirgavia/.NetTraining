namespace ChefLibrary.Products.AnimalOriginProducts
{
    public class Egg : AnimalOriginProduct
    {
        public Egg(
            string name,
            double weight,
            Caloricity caloricity,
            string animal,
            Conditions condition)
            : base(name, weight, caloricity, animal, condition)
        {
        }

        public override void Boil()
        {
            this.Conditions = Conditions.Boil;
            this.Caloricity.Proteins -= Constants.EggBoilingLossPercentage * this.Caloricity.Proteins;
            this.Caloricity.Fats -= Constants.EggBoilingLossPercentage * this.Caloricity.Fats;
            this.Caloricity.Carbohydrates -= Constants.EggBoilingLossPercentage * this.Caloricity.Carbohydrates;
        }

        public override void Fry()
        {
            this.Conditions = Conditions.Fry;
            this.Caloricity.Proteins -= Constants.EggFryingLossPercentage * this.Caloricity.Proteins;
            this.Caloricity.Fats -= Constants.EggFryingLossPercentage * this.Caloricity.Fats;
            this.Caloricity.Carbohydrates -= Constants.EggFryingLossPercentage * this.Caloricity.Carbohydrates;
        }

        public override void Bake()
        {
            this.Conditions = Conditions.Bake;
            this.Caloricity.Proteins -= Constants.EggBakingLossPercentage * this.Caloricity.Proteins;
            this.Caloricity.Fats -= Constants.EggBakingLossPercentage * this.Caloricity.Fats;
            this.Caloricity.Carbohydrates -= Constants.EggBakingLossPercentage * this.Caloricity.Carbohydrates;
        }
    }
}
