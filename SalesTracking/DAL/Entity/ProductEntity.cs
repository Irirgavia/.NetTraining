namespace DAL.Entity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Products")]
    public class ProductEntity : IIdentifier
    {
        public ProductEntity(string name)
        {
            Name = name;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}