namespace BLEntity
{
    public class ClientDTO
    {
        public ClientDTO()
        {
        }

        public int Id { get; }

        public UserDTO User { get; set; }

        public CredentialsDTO Credentials { get; set; }
    }
}