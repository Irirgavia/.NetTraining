namespace DAL.Entity
{
    public class UserEntity
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

        public int Id { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Role { get; set; }
    }
}
