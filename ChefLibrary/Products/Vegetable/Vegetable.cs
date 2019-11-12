using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ChefLibrary.Products.ProductTypes.ProductTypes;

namespace ChefLibrary.Products.Vegetable
{
    public class Vegetable: Product
    {
        public string Condition { get; private set; }
        public Vegetable(
            string name,
            double weight,
            Caloricity caloricity,
            string condition
            ) : base(name, weight, caloricity)
        {
            Condition = condition;
        }
        public override string ToString()
        {
            return $"{base.ToString()} {Condition}";
        }
    }
}
