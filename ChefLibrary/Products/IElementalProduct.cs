using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChefLibrary.Products
{
    public interface IElementalProduct
    {
        void Wash();

        void Chop();

        void Boil();

        void Fry();

        void Bake();
    }
}
