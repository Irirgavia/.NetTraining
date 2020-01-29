namespace DAL.Repositories.Interfaces
{
    using DAL.Entity;

    public interface IRoleRepository : IGenericRepository<RoleEntity>
    {
        RoleEntity GetRoleById(int id);

        RoleEntity GetRoleByName(string name);

        void AddRole(string name);

        void DeleteRole(int id);

        void DeleteRole(string name);

        void UpdateRole(int id, string name);
    }
}