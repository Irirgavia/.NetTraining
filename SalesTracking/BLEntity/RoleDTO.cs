namespace BLEntity
{
    public class RoleDTO
    {
        public RoleDTO()
        {
        }

        public RoleDTO(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; }

        public string Name { get; set; }
    }
}