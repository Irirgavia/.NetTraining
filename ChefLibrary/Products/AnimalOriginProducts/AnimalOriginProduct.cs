namespace ChefLibrary.Products.AnimalOriginProducts
{
    public abstract class AnimalOriginProduct : Product, IElementalProduct
    {
        protected AnimalOriginProduct(
            string name,
            double weight,
            Caloricity caloricity,
            string animal,
            Constants.Conditions conditions)
            : base(name, weight, caloricity, Constants.AnimalDigestionPercent)
        {
            this.Animal = animal;
            this.Conditions = conditions;
            this.IsChop = false;
            this.IsWash = false;
        }

        public string Animal { get; private set; }

        public Constants.Conditions Conditions { get; set; }

        public bool IsChop { get; set; }

        public bool IsWash { get; set; }

        public override double GetProductCalories()
        {
            return base.GetProductCalories() * this.DigestionPercent;
        }

        public void Wash()
        {
            this.IsWash = true;
        }

        public void Chop()
        {
            this.IsChop = true;
        }

        public abstract void Boil();

        public abstract void Fry();

        public abstract void Bake();

        public override string ToString()
        {
            return $"{base.ToString()} {this.Animal} {this.Conditions}";
        }
    }
}
