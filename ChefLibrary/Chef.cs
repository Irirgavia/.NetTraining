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

        public static double CalculateSumByProperty(ISalad salad, Func<IProduct, double> propertySelector)
        {
            return salad.Products.Sum(propertySelector);
        }

        public static double GetSaladWeight(ISalad salad)
        {
            return CalculateSumByProperty(
                salad,
                x => x.Weight);
        }

        public static double GetSaladCalories(ISalad salad)
        {
            return CalculateSumByProperty(
                salad,
                x => x.GetProductCalories());
        }

        public static IEnumerable<IProduct> FindProductByProperty(IEnumerable<IProduct> products, Func<IProduct, bool> propertySelector)
        {
            return products.Where(propertySelector);
        }

        public static IEnumerable<IProduct> FindProductsByName(ISalad salad, string nameProduct)
        {
            var foundProducts = FindProductByProperty(
                salad.Products,
                x => x.Name == nameProduct);

            if (foundProducts == null)
            {
                throw new ArgumentException($"There is no component with name {nameProduct}.");
            }

            return foundProducts;
        }

        public static IEnumerable<IProduct> FindProductsByWeight(ISalad salad, double weight)
        {
            var findProducts = FindProductByProperty(
                salad.Products,
                x => Math.Abs(x.Weight - weight) < 0);

            if (findProducts == null)
            {
                throw new ArgumentException($"There is no component with weight {weight}.");
            }

            return findProducts;
        }

        public static IEnumerable<IProduct> FindProductsByCalories(ISalad salad, double beginValue, double endValue)
        {
            var findProducts = FindProductByProperty(
                salad.Products,
                x => x.GetProductCalories() > beginValue && x.GetProductCalories() < endValue);

            if (findProducts == null)
            {
                throw new ArgumentException($"There is no component with {beginValue} - {endValue} calories.");
            }

            return findProducts;
        }

        public static IEnumerable<IProduct> SortProductsByProperty<T>(IEnumerable<IProduct> products, Func<IProduct, T> propertySelector)
        {
            return products.OrderBy(propertySelector);
        }

        public static IEnumerable<IProduct> SortSaladByName(ISalad salad)
        {
            return SortProductsByProperty(
                salad.Products,
                x => x.Name);
        }

        public static IEnumerable<IProduct> SortSaladByWeight(ISalad salad)
        {
            return SortProductsByProperty(
                salad.Products,
                x => x.Weight);
        }

        public static IEnumerable<IProduct> SortSaladByCalories(ISalad salad)
        {
            return SortProductsByProperty(
                salad.Products,
                x => x.GetProductCalories());
        }

        public ISalad BuildSalad()
        {
            return this.saladBuilder.GetSalad();
        }

        public ISalad BuildSalad(ISaladBuilder saladBuilder)
        {
            return saladBuilder.GetSalad();
        }
    }
}
