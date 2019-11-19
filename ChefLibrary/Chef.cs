namespace ChefLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using ChefLibrary.Builders;
    using ChefLibrary.Products;

    public class Chef
    {
        private ISaladBuilder saladBuilder;

        public Chef(ISaladBuilder saladBuilder)
        {
            this.saladBuilder = saladBuilder;
        }

        public ISaladBuilder SaladBuilder
        {
            set => this.saladBuilder = value;
        }

        public ISalad BuildSalad()
        {
            return this.saladBuilder.GetSalad();
        }

        public ISalad BuildSalad(ISaladBuilder saladBuilder)
        {
            return saladBuilder.GetSalad();
        }

        public double CalculateSumByProperty(ISalad salad, Func<IProduct, double> propertySelector)
        {
            return salad.Products.Sum(propertySelector);
        }

        public double GetSaladWeight(ISalad salad)
        {
            return this.CalculateSumByProperty(
                salad,
                x => x.Weight);
        }

        public double GetSaladCalories(ISalad salad)
        {
            return this.CalculateSumByProperty(
                salad,
                x => x.GetProductCalories());
        }

        public IEnumerable<IProduct> FindProductByProperty(IEnumerable<IProduct> products, Func<IProduct, bool> propertySelector)
        {
            return products.Where(propertySelector);
        }

        public IEnumerable<IProduct> FindProductsByName(ISalad salad, string nameProduct)
        {
            var foundProducts = this.FindProductByProperty(
                salad.Products,
                x => x.Name == nameProduct);

            if (foundProducts == null)
            {
                throw new ArgumentException($"There is no component with name {nameProduct}.");
            }

            return foundProducts;
        }

        public IEnumerable<IProduct> FindProductsByWeight(ISalad salad, double weight)
        {
            var findProducts = this.FindProductByProperty(
                salad.Products, 
                x => Math.Abs(x.Weight - weight) < 0);

            if (findProducts == null)
            {
                throw new ArgumentException($"There is no component with weight {weight}.");
            }

            return findProducts;
        }

        public IEnumerable<IProduct> FindProductsByCalories(ISalad salad, double beginValue, double endValue)
        {
            var findProducts = this.FindProductByProperty(
                salad.Products,
                x => x.GetProductCalories() > beginValue && x.GetProductCalories() < endValue);

            if (findProducts == null)
            {
                throw new ArgumentException($"There is no component with {beginValue} - {endValue} calories.");
            }

            return findProducts;
        }

        public IEnumerable<IProduct> SortProductsByProperty<T>(IEnumerable<IProduct> products, Func<IProduct, T> propertySelector)
        {
            return products.OrderBy(propertySelector);
        }
         
        public IEnumerable<IProduct> SortSaladByName(ISalad salad)
        {
            return this.SortProductsByProperty(
                salad.Products, 
                x => x.Name);
        }

        public IEnumerable<IProduct> SortSaladByWeight(ISalad salad)
        {
            return this.SortProductsByProperty(
                salad.Products, 
                x => x.Weight);
        }

        public IEnumerable<IProduct> SortSaladByCalories(ISalad salad)
        {
            return this.SortProductsByProperty(
                salad.Products, 
                x => x.GetProductCalories());
        }
    }
}
