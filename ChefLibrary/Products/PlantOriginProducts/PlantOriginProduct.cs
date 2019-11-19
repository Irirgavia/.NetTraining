namespace ChefLibrary.Products.PlantOriginProducts
{
    public abstract class PlantOriginProduct : Product, IElementalProduct
    {
        protected PlantOriginProduct(
            string name,
            double weight,
            Caloricity caloricity,
            Conditions conditions)
            : base(name, weight, caloricity, Constants.PlantDigestionPercent)
        {
            this.Conditions = conditions;
            this.IsPeel = false;
            this.IsChop = false;
            this.IsWash = false;
        }

        public Conditions Conditions { get; set; }

        public bool IsChop { get; set; }

        public bool IsWash { get; set; }

        public bool IsPeel { get; set; }

        public override double GetProductCalories()
        {
            return this.Weight
                   * Constants.WeightCoefficientPer100G
                   * (this.Caloricity.GetCaloriesPer1G() + Constants.PectinsEnergyValue)
                   * this.DigestionPercent;
        }

        public override string ToString()
        {
            return $"{base.ToString()} {this.Conditions} wash: {this.IsWash} skin: {this.IsPeel} chop: {this.IsChop}";
        }

        public void Wash()
        {
            this.IsWash = true;
        }

        public void Chop()
        {
            this.IsChop = true;
        }

        public void PeelOff()
        {
            this.IsPeel = false;
        }

        public abstract void Boil();

        public abstract void Fry();

        public abstract void Bake();
    }
}
