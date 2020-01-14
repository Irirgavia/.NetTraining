namespace BLEntity
{
    public class Product : IIdentifier
    {
        public Product()
        {
        }

        public Product(string name)
        {
            Name = name;
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}