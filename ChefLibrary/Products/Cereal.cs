using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ChefLibrary.Products.ProductTypes.ProductTypes;

namespace ChefLibrary.Products
{
    public class Cereal: Product
    {
        public CerealType CerealType { get; private set; }
        public Cereal(
            string name,
            double weight,
            Caloricity caloricity,
            CerealType cerealType
            ) : base(name, weight, caloricity)
        {
            CerealType = cerealType;
        }
        public override string ToString()
        {
            return $"{base.ToString()} {CerealType}";
        }
    }
}
