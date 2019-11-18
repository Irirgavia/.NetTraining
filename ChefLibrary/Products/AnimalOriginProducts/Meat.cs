namespace ChefLibrary.Products.AnimalOriginProducts
{
    public class Meat : AnimalOriginProduct
    {
        public Meat(
            string name,
            double weight,
            Caloricity caloricity,
            string animal,
            Constants.Conditions condition)
            : base(name, weight, caloricity, animal, condition)
        {
        }

        public override void Boil()
        {
            this.Conditions = Constants.Conditions.Boil;
            this.Caloricity.Proteins -= Constants.MeatBoilingLossPercentage * this.Caloricity.Proteins;
            this.Caloricity.Fats -= Constants.MeatBoilingLossPercentage * this.Caloricity.Fats;
            this.Caloricity.Carbohydrates -= Constants.MeatBoilingLossPercentage * this.Caloricity.Carbohydrates;
        }

        public override void Fry()
        {
            this.Conditions = Constants.Conditions.Fry;
            this.Caloricity.Proteins -= Constants.MeatFryingLossPercentage * this.Caloricity.Proteins;
            this.Caloricity.Fats -= Constants.MeatFryingLossPercentage * this.Caloricity.Fats;
            this.Caloricity.Carbohydrates -= Constants.MeatFryingLossPercentage * this.Caloricity.Carbohydrates;
        }

        public override void Bake()
        {
            this.Conditions = Constants.Conditions.Bake;
            this.Caloricity.Proteins -= Constants.MeatBakingLossPercentage * this.Caloricity.Proteins;
            this.Caloricity.Fats -= Constants.MeatBakingLossPercentage * this.Caloricity.Fats;
            this.Caloricity.Carbohydrates -= Constants.MeatBakingLossPercentage * this.Caloricity.Carbohydrates;
        }

        public override string ToString()
        {
            return $"{base.ToString()}";
        }
    }
}
