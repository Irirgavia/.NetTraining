using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ChefLibrary.Products.Fruit.FruitTypes;

namespace ChefLibrary.Products.Fruit
{
    public class Apple : Fruit
    {
        public AppleType AppleType { get; private set; }
        public Apple(
            string name,
            double weight,
            Caloricity caloricity,
            string condition,
            AppleType appleType
            ) : base(name, weight, caloricity, condition)
        {
            AppleType = appleType;
        }
        public override string ToString()
        {
            return $"{base.ToString()} {AppleType}";
        }
    }
}
