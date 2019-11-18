namespace ChefLibrary.Products
{
    public abstract class Product : IProduct
    {
        protected readonly double DigestionPercent;

        protected Product(
            string name,
            double weight,
            Caloricity caloricity,
            double digestionPercent = 0)
        {
            this.Name = name;
            this.Weight = weight;
            this.Caloricity = caloricity;
            this.DigestionPercent = digestionPercent;
        }

        public string Name { get; set; }

        public double Weight { get; set; }

        public Caloricity Caloricity { get; private set; }

         
        public virtual double GetProductCalories()
        {
            return this.Weight * Constants.WeightCoefficientPer100G * this.Caloricity.GetCaloriesPer1G();
        }

        public override string ToString()
        {
            return $"{this.Name}: {this.Weight}g {this.Caloricity}";
        }
    }
}
