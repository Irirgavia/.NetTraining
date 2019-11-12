using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ChefLibrary.Products.Cereal.CerealTypes;

namespace ChefLibrary.Products.Cereal
{
    public class Buckwheat: Cereal
    {
        public BuckwheatType BuckwheatType { get; private set; }
        public Buckwheat(
            string name,
            double weight,
            Caloricity caloricity,
            string baseType,
            BuckwheatType buckwheatType
            ) : base(name, weight, caloricity, baseType)
        {
            BuckwheatType = buckwheatType;
        }
        public override string ToString()
        {
            return $"{base.ToString()} {BuckwheatType}";
        }
    }
}
