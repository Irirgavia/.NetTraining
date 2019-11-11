using static ChefLibrary.Products.Cereal.CerealTypes;

namespace ChefLibrary.Products.Cereal
{
    public class Cereal: Product
    {
        public string BaseType { get; private set; }
        public Cereal(
            string name,
            double weight,
            Caloricity caloricity,
            string baseType
            ) : base(name, weight, caloricity)
        {
            BaseType = baseType;
        }
        public override string ToString()
        {
            return $"{base.ToString()} {BaseType}";
        }
    }
}
