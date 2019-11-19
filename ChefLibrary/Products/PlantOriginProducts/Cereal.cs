namespace ChefLibrary.Products.PlantOriginProducts
{
    public class Cereal : PlantOriginProduct
    {
        public Cereal(
            string name,
            double weight,
            Caloricity caloricity,
            Conditions condition,
            string basis)
            : base(name, weight, caloricity, condition)
        {
            this.Basis = basis;
        }

        public string Basis { get; private set; }

        public override void Boil()
        {
            this.Conditions = Conditions.Boil;
            this.Caloricity.Proteins -= Constants.CerealBoilingLossPercentage * this.Caloricity.Proteins;
            this.Caloricity.Fats -= Constants.CerealBoilingLossPercentage * this.Caloricity.Fats;
            this.Caloricity.Carbohydrates -= Constants.CerealBoilingLossPercentage * this.Caloricity.Carbohydrates;
        }

        public override void Fry()
        {
            this.Conditions = Conditions.Fry;
            this.Caloricity.Proteins -= Constants.CerealFryingLossPercentage * this.Caloricity.Proteins;
            this.Caloricity.Fats -= Constants.CerealFryingLossPercentage * this.Caloricity.Fats;
            this.Caloricity.Carbohydrates -= Constants.CerealFryingLossPercentage * this.Caloricity.Carbohydrates;
        }

        public override void Bake()
        {
            this.Conditions = Conditions.Bake;
            this.Caloricity.Proteins -= Constants.CerealBakingLossPercentage * this.Caloricity.Proteins;
            this.Caloricity.Fats -= Constants.CerealBakingLossPercentage * this.Caloricity.Fats;
            this.Caloricity.Carbohydrates -= Constants.CerealBakingLossPercentage * this.Caloricity.Carbohydrates;
        }

        public override string ToString()
        {
            return $"{base.ToString()} {this.Basis}";
        }
    }
}
