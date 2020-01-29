namespace BLEntity
{
    using DAL.Entity;

    public class CredentialsDTO
    {
        public CredentialsDTO()
        {
        }

        public CredentialsDTO(int id, string login, string password, RoleDTO role)
        {
            Id = id;
            Login = login;
            Password = password;
            Role = role;
        }

        public int Id { get; }

        public string Login { get; set; }

        public string Password { get; set; }

        public RoleDTO Role { get; set; }
    }
}