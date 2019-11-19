namespace ChefLibrary.Products.MixedProducts
{
    public abstract class MixedProduct : Product
    {
        protected MixedProduct(
            string name,
            double weight,
            Caloricity caloricity)
            : base(name, weight, caloricity, Constants.MixedDigestionPercent)
        {
        }

        public override double GetProductCalories()
        {
            return base.GetProductCalories() * this.DigestionPercent;
        }

        public override string ToString()
        {
            return $"{base.ToString()} ";
        }
    }
}
