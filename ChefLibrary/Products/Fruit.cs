using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ChefLibrary.Products.ProductTypes.ProductTypes;

namespace ChefLibrary.Products
{
    public class Fruit: Product
    {
        public FruitType FruitType { get; private set; }
        public Fruit(
            string name,
            double weight,
            Caloricity caloricity,
            FruitType fruitType
            ) : base(name, weight, caloricity)
        {
            FruitType = fruitType;
        }
        public override string ToString()
        {
            return $"{base.ToString()} {FruitType}";
        }
    }
}
