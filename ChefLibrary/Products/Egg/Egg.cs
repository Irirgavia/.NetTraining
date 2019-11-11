namespace ChefLibrary.Products.Egg
{
    public class Egg : Product
    {
        public string Animal { get; private set; }
        public string Сondition { get; private set; }
        public Egg(
            string name,
            double weight,
            Caloricity caloricity,
            string animal,
            string condition
            ) : base(name, weight, caloricity)
        {
            Animal = animal;
            Сondition = condition;
        }
        public override string ToString()
        {
            return $"{base.ToString()} {Сondition}";
        }
    }
}
