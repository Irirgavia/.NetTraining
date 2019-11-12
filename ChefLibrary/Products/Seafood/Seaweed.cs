using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ChefLibrary.Products.Seafood.SeafoodTypes;

namespace ChefLibrary.Products.Seafood
{
    public class Seaweed : Seafood
    {
        public SeaweedType SeaweedType { get; private set; }
        public Seaweed(
            string name,
            double weight,
            Caloricity caloricity,
            string waterType,
            SeaweedType seaweedType
            ) : base(name, weight, caloricity, waterType)
        {
            SeaweedType = seaweedType;
        }
        public override string ToString()
        {
            return $"{base.ToString()} {SeaweedType}";
        }
    }
}
