using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ChefLibrary.Products.ProductTypes.ProductTypes;

namespace ChefLibrary.Products
{
    public class Sauce: Product
    {
        public string SauseType { get; private set; }
        public Sauce(
            string name,
            double weight,
            Caloricity caloricity,
            string sauseType
            ) : base(name, weight, caloricity)
        {
            SauseType = sauseType;
        }
        public override string ToString()
        {
            return $"{base.ToString()} {SauseType}";
        }
    }
}
