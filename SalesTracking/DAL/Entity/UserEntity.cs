namespace DAL.Entity
{
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Users")]
    public class UserEntity : IIdentifier
    {
        public UserEntity()
        {
            Role = "User";
        }

        public UserEntity(string lastName, string firstName = "")
        {
            UserName = "userName";
            FirstName = firstName;
            LastName = lastName;
            Role = "User";
        }

        public UserEntity(string userName, string firstName, string lastName, string email)
        {
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Role = "User";
        }

        [Key]
        public int Id { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Role { get; set; }

        public ICollection<SaleEntity> Sales { get; }
    }
}
