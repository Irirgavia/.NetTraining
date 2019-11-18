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

        public ISaladBuilder SaladBuilder
        {
            set => this.saladBuilder = value;
        }

        public Salad BuildSalad(IEnumerable<Product> products)
        {
            foreach (var product in products)
            {
                this.saladBuilder.AddProduct(product);
            }

            this.saladBuilder.MixProduct();
            return this.saladBuilder.GetSalad();
        }

        public double GetSaladWeight(ISalad salad)
        {
            return salad.GetAllProducts().Sum(x => x.Weight);
        }

        public double GetSaladCalories(ISalad salad)
        {
            return salad.GetAllProducts().Sum(x => x.GetProductCalories());
        }

        public IEnumerable<IProduct> GetProductsList(IEnumerable<Product> products, Func<Product, bool> propertySelector)
        {
            return products.Where(propertySelector);
        }

        public IEnumerable<IProduct> FindProductsByName(ISalad salad, string nameProduct)
        {
            var foundProducts = this.GetProductsList(
                salad.GetAllProducts(),
                x => x.Name == nameProduct);

            if (foundProducts == null)
            {
                throw new ArgumentException($"There is no component with name {nameProduct}.");
            }

            return foundProducts;
        }

        public IEnumerable<IProduct> FindProductsByWeight(ISalad salad, double weight)
        {
            var findProducts = this.GetProductsList(
                salad.GetAllProducts(), 
                x => Math.Abs(x.Weight - weight) < 0);

            if (findProducts == null)
            {
                throw new ArgumentException($"There is no component with weight {weight}.");
            }

            return findProducts;
        }

        public IEnumerable<IProduct> FindProductsByCalories(ISalad salad, double beginValue, double endValue)
        {
            var findProducts = this.GetProductsList(
                salad.GetAllProducts(),
                x => x.GetProductCalories() > beginValue && x.GetProductCalories() < endValue);

            if (findProducts == null)
            {
                throw new ArgumentException($"There is no component with {beginValue} - {endValue} calories.");
            }

            return findProducts;
        }

        public IEnumerable<IProduct> SortProductsList<T>(IEnumerable<Product> products, Func<Product, T> propertySelector)
        {
            return products.OrderBy(propertySelector);
        }
         
        public IEnumerable<IProduct> SortSaladByName(ISalad salad)
        {
            return this.SortProductsList(
                salad.GetAllProducts(), 
                x => x.Name);
        }

        public IEnumerable<IProduct> SortSaladByWeight(ISalad salad)
        {
            return this.SortProductsList(
                salad.GetAllProducts(), 
                x => x.Weight);
        }

        public IEnumerable<IProduct> SortSaladByCalories(ISalad salad)
        {
            return this.SortProductsList(
                salad.GetAllProducts(), 
                x => x.GetProductCalories());
        }
    }
}
