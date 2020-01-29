namespace DAL.Entity
{
    using System.ComponentModel.DataAnnotations;

    public class RoleEntity : IIdentifier
    {
        [Key]
        public int Id { get; }

        [Required]
        public string Name { get; set; }
    }
}