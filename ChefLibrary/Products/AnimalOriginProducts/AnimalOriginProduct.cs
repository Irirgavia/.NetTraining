namespace ChefLibrary.Products.AnimalOriginProducts
{
    public abstract class AnimalOriginProduct : Product, IElementalProduct
    {
        protected AnimalOriginProduct(
            string name,
            double weight,
            Caloricity caloricity,
            string animal,
            Conditions conditions)
            : base(name, weight, caloricity, Constants.AnimalDigestionPercent)
        {
            this.Animal = animal;
            this.Conditions = conditions;
            this.IsChop = false;
            this.IsWash = false;
            this.IsSkin = false;
        }

        public string Animal { get; private set; }

        public Conditions Conditions { get; set; }

        public bool IsChop { get; set; }

        public bool IsWash { get; set; }

        public bool IsSkin { get; set; }

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

        public void SkinOff()
        {
            this.IsSkin = false;
        }

        public abstract void Boil();

        public abstract void Fry();

        public abstract void Bake();

        public override string ToString()
        {
            return $"{base.ToString()} {this.Animal} {this.Conditions} wash: {this.IsWash} skin: {this.IsSkin} chop: {this.IsChop}";
        }
    }
}
