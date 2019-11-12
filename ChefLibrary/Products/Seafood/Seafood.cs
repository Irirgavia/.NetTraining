using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ChefLibrary.Products.ProductTypes.ProductTypes;

namespace ChefLibrary.Products.Seafood
{
    public class Seafood: Product
    {
        public string WaterType { get; private set; }
        public Seafood(
            string name,
            double weight,
            Caloricity caloricity,
            string waterType
            ) : base(name, weight, caloricity)
        {
            WaterType = waterType;
        }
        public override string ToString()
        {
            return $"{base.ToString()} {WaterType}";
        }
    }
}
