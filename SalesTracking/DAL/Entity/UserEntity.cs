namespace DAL.Entity
{
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Users")]
    public class UserEntity : IIdentifier
    {
        public UserEntity(int id, string lastName, string firstName = "", string email = "")
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        public UserEntity(string lastName, string firstName = "", string email = "")
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        [Key]
        public int Id { get; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public ICollection<SaleEntity> Sales { get; }
    }
}
