using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ChefLibrary.Products.Cereal.CerealTypes;

namespace ChefLibrary.Products.Cereal
{
    public class Rice: Cereal
    {
        public RiceType RiceType { get; private set; }
        public Rice(
            string name,
            double weight,
            Caloricity caloricity,
            string baseType,
            RiceType riceType
            ) : base(name, weight, caloricity, baseType)
        {
            RiceType = riceType;
        }
        public override string ToString()
        {
            return $"{base.ToString()} {RiceType}";
        }
    }
}
