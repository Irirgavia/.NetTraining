namespace DAL.Entity
{
    public class ProductEntity : IIdentifier
    {
        public ProductEntity(string name)
        {
            Name = name;
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}