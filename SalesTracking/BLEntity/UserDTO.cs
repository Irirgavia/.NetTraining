namespace BLEntity
{
    public class UserDTO
    {
        public UserDTO()
        {
        }

        public UserDTO(string lastName, string firstName = "", string email = "")
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        public int Id { get; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

    }
}
