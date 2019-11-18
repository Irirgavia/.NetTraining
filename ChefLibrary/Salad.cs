namespace ChefLibrary
{
    using System.Collections.Generic;
    using System.Text;

    using ChefLibrary.Products;

    public class Salad : ISalad
    {
        public Salad(
            string name,
            List<Product> products)
        {
            this.Name = name;
            this.Products = products;
        }

        public string Name { get; private set; }

        public List<Product> Products { get; private set; }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder($"Salad name: {this.Name},");
            foreach (var product in this.Products)
            {
                stringBuilder.Append($" {product},");
            }

            return stringBuilder.ToString().TrimEnd(',');
        }

        public List<Product> GetAllProducts()
        {
            return this.Products;
        }

        public void AddProduct(Product product)
        {
            this.Products.Add(product);
        }

        public void RemoveProduct(Product product)
        {
            this.Products.Remove(product);
        }
    }
}
