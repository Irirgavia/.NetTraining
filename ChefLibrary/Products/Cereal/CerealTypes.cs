using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChefLibrary.Products.Cereal
{
    public static class CerealTypes
    {
        public enum OatemalType
        {
            OatemalExtra,
            OatemalHercules,
            OatemalBran,
            OatemalGroats,
            FlattenedOatmeal,
            UncutOatmeal,
        }
        public enum RiceType
        {
            LongGrainRice,
            MediumGrainRice,
            RoundGrainRice,
            UnpolishedRice,
            SteamedRice,
        }
        public enum BuckwheatType {
            BuckwheatFlakes,
            BuckwheatFlour,
            ProdelBuckwheat,
            GroundBuckwheat,
            UngroundBuckwheat,
        }
    }
}
