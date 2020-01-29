namespace BLEntity
{
    public class ProductDTO : IIdentifier
    {
        public ProductDTO()
        {
        }

        public ProductDTO(string name)
        {
            Name = name;
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}