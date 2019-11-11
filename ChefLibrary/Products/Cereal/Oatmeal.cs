using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ChefLibrary.Products.Cereal.CerealTypes;

namespace ChefLibrary.Products.Cereal
{
    public class Oatmeal: Cereal
    {
        public OatemalType OatemalType { get; private set; }
        public Oatmeal(
            string name,
            double weight,
            Caloricity caloricity,
            BaseType baseType,
            OatemalType oatemalType
            ) : base(name, weight, caloricity, baseType)
        {
            OatemalType = oatemalType;
        }
        public override string ToString()
        {
            return $"{base.ToString()} {OatemalType}";
        }
    }
}
