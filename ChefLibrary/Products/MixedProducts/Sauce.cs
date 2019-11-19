namespace ChefLibrary.Products.MixedProducts
{
    public class Sauce : MixedProduct
    {
        public Sauce(
            string name,
            double weight,
            Caloricity caloricity,
            SauceСonsistency consistency)
            : base(name, weight, caloricity)
        {
            this.Consistency = consistency;
        }

        public SauceСonsistency Consistency { get; private set; }

        public override string ToString()
        {
            return $"{base.ToString()} {this.Consistency}";
        }
    }
}
