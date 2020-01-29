namespace DAL.Entity
{
    using System.ComponentModel.DataAnnotations;

    public class CredentialsEntity : IIdentifier
    {
        [Key]
        public int Id { get; }

        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public RoleEntity Role { get; set; }
    }
}