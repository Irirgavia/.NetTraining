using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ChefLibrary.Products.ProductTypes.ProductTypes;

namespace ChefLibrary.Products.Fruit
{
    public class Fruit: Product
    {
        public string Condition { get; private set; }
        public Fruit(
            string name,
            double weight,
            Caloricity caloricity,
            string fruitType
            ) : base(name, weight, caloricity)
        {
            Condition = fruitType;
        }
        public override string ToString()
        {
            return $"{base.ToString()} {Condition}";
        }
    }
}
