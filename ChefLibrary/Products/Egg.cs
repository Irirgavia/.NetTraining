using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ChefLibrary.Products.ProductTypes.ProductTypes;

namespace ChefLibrary.Products
{
    public class Egg : Product
    {
        public EggType EggType { get; private set; }
        public Egg(
            string name,
            double weight,
            Caloricity caloricity,
            EggType eggType
            ) : base(name, weight, caloricity)
        {
            EggType = eggType;
        }
        public override string ToString()
        {
            return $"{base.ToString()} {EggType}";
        }
    }
}
