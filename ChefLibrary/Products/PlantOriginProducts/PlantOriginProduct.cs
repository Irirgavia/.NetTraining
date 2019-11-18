namespace ChefLibrary.Products.PlantOriginProducts
{
    public abstract class PlantOriginProduct : Product, IElementalProduct
    {
        protected PlantOriginProduct(
            string name,
            double weight,
            Caloricity caloricity,
            Constants.Conditions conditions)
            : base(name, weight, caloricity, Constants.PlantDigestionPercent)
        {
            this.PeelPresence = false;
            this.IsChop = false;
            this.IsWash = false;
        }

        public bool PeelPresence { get; set; }

        public Constants.Conditions Conditions { get; set; }

        public bool IsChop { get; set; }

        public bool IsWash { get; set; }

        public override double GetProductCalories()
        {
            return this.Weight
                   * Constants.WeightCoefficientPer100G
                   * (this.Caloricity.GetCaloriesPer1G() + Constants.PectinsEnergyValue)
                   * this.DigestionPercent;
        }

        public void Wash()
        {
            this.IsWash = true;
        }

        public void Chop()
        {
            this.IsChop = true;
        }

        public void PellOff()
        {
            this.PeelPresence = false;
        }

        public abstract void Boil();

        public abstract void Fry();

        public abstract void Bake();
    }
}
