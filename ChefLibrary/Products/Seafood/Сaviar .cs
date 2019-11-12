using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ChefLibrary.Products.Seafood.SeafoodTypes;

namespace ChefLibrary.Products.Seafood
{
    public class Сaviar : Seafood
    {
        public CaviarType СaviarType { get; private set; }
        public Сaviar(
            string name,
            double weight,
            Caloricity caloricity,
            string waterType,
            CaviarType caviarType
            ) : base(name, weight, caloricity, waterType)
        {
            СaviarType = caviarType;
        }
        public override string ToString()
        {
            return $"{base.ToString()} {СaviarType}";
        }
    }
}
