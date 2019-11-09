using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ChefLibrary.Products.ProductTypes.ProductTypes;

namespace ChefLibrary.Products
{
    public class Seafood: Product
    {
        public SeafoodType SeafoodType { get; private set; }
        public Seafood(
            string name,
            double weight,
            Caloricity caloricity,
            SeafoodType seafoodType
            ) : base(name, weight, caloricity)
        {
            SeafoodType = seafoodType;
        }
        public override string ToString()
        {
            return $"{base.ToString()} {SeafoodType}";
        }
    }
}
