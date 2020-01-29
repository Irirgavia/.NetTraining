namespace DAL.Repositories
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    using DAL.Entity;
    using DAL.Repositories.Interfaces;

    public class RoleRepository : GenericRepository<RoleEntity, ClientsContext>, IRoleRepository
    {
        public RoleRepository(ClientsContext context)
            : base(context)
        {
        }

        public RoleEntity GetRoleById(int id)
        {
            return Context.Roles.FirstOrDefault(x => x.Id == id);
        }

        public RoleEntity GetRoleByName(string name)
        {
            return Context.Roles.FirstOrDefault(x => x.Name == name);
        }

        public void AddRole(string name)
        {
            Context.Roles.Add(new RoleEntity { Name = name });
        }

        public void DeleteRole(int id)
        {
            var role = GetRoleById(id);
            if (role != null)
            {
                Context.Roles.Remove(role);
            }
        }

        public void DeleteRole(string name)
        {
            var role = GetRoleByName(name);
            if (role != null)
            {
                Context.Roles.Remove(role);
            }
        }

        public void UpdateRole(int id, string name)
        {
            var role = GetRoleById(id);
            if (role != null)
            {
                role.Name = name;
            }
        }
    }
}