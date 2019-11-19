namespace ChefLibrary
{
    using System.Collections.Generic;
    using System.Text;

    using ChefLibrary.Products;

    public class Salad : ISalad
    {
        public Salad(
            string name,
            List<IProduct> products)
        {
            this.Name = name;
            this.Products = products;
        }

        public string Name { get; private set; }

        public List<IProduct> Products { get; private set; }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder($"Salad name: {this.Name}, \n");
            foreach (var product in this.Products)
            {
                stringBuilder.Append($" {product},\n");
            }

            return stringBuilder.ToString().TrimEnd(',');
        }

        public List<IProduct> GetAllProducts()
        {
            return this.Products;
        }

        public void AddProduct(IProduct product)
        {
            this.Products.Add(product);
        }

        public void RemoveProduct(IProduct product)
        {
            this.Products.Remove(product);
        }
    }
}
