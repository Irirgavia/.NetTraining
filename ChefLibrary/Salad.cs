using ChefLibrary.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChefLibrary
{
    public class Salad
    {
        public string Name { get; private set; }
        public List<Product> Products { get; private set; }

        public Salad(
            string name,
            List<Product> products)
        {
            Name = name;
            Products = products;
        }
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder($"Salad name: {Name}");
            foreach (var product in Products)
            {
                stringBuilder.Append(product.ToString());
            }

            return stringBuilder.ToString();
        }
        public double GetWeight()
        {
            double weight = 0;
            foreach (var product in Products)
            {
                weight += product.Weight;
            }

            return weight;
        }
        public double GetCalories()
        {
            double calories = 0;
            foreach (var product in Products)
            {
                calories += product.GetProductCalories();
            }

            return calories;
        }
        public void AddProduct(Product product)
        {
            Products.Add(product);
        }
        public void RemoveProduct(Product product)
        {
            Products.Remove(product);
        }
        public List<Product> FindProductsByName(string nameProduct)
        {
            var findedProduct = from product in Products
                                where String.Compare(product.Name, nameProduct) == 0
                                select product;

            if (findedProduct == null)
            {
                throw new ArgumentException($"There is no component with name {nameProduct}.");
            }
            return findedProduct.ToList<Product>();
        }
        public List<Product> FindProductsByWeigth(double weigth)
        {
            var findedProduct = from product in Products
                                where product.Weight == weigth
                                select product;

            if (findedProduct == null)
            {
                throw new ArgumentException($"There is no component with weigth {weigth}.");
            }
            return findedProduct.ToList<Product>();
        }
        public List<Product> FindProductsByCalories(double beginValue, double endValue)
        {
            var findedProduct = from product in Products
                                where product.GetProductCalories() >= beginValue && product.GetProductCalories() <= endValue
                                select product;

            if (findedProduct == null)
            {
                throw new ArgumentException($"There is no component with {beginValue} - {endValue} calories.");
            }
            return findedProduct.ToList<Product>();
        }
        public List<Product> SortByName()
        {
            var sortedProduct = from product in Products
                                orderby product.Name
                                select product;

            return sortedProduct.ToList<Product>();
        }
        public List<Product> SortByWeigth()
        {
            var sortedProduct = from product in Products
                                orderby product.Weight
                                select product;

            return sortedProduct.ToList<Product>();
        }
        public List<Product> SortByCalories()
        {
            var sortedProduct = from product in Products
                                orderby product.GetProductCalories()
                                select product;

            return sortedProduct.ToList<Product>();
        }
    }
}
