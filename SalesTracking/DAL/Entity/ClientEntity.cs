namespace DAL.Entity
{
    using System.ComponentModel.DataAnnotations;

    public class ClientEntity : IIdentifier
    {
        [Key]
        public int Id { get; }

        [Required]
        public UserEntity User { get; set; }

        [Required]
        public CredentialsEntity Credentials { get; set; }
    }
}