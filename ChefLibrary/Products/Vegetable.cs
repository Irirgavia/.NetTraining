using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ChefLibrary.Products.ProductTypes.ProductTypes;

namespace ChefLibrary.Products
{
    public class Vegetable: Product
    {
        public VegetableType VegetableType { get; private set; }
        public Vegetable(
            string name,
            double weight,
            Caloricity caloricity,
            VegetableType vegetableType
            ) : base(name, weight, caloricity)
        {
            VegetableType = vegetableType;
        }
        public override string ToString()
        {
            return $"{base.ToString()} {VegetableType}";
        }
    }
}
