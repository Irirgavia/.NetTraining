namespace DAL.Repositories
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    using DAL.Entity;
    using DAL.Repositories.Interfaces;

    public class UserRepository : GenericRepository<UserEntity, ClientsContext>, IUserRepository
    {
        public UserRepository(ClientsContext context)
            : base(context)
        {
        }

        public UserEntity GetUserById(int id)
        {
            return Context.Users.FirstOrDefault(x => x.Id == id);
        }

        public UserEntity GetUserByLastName(string lastName)
        {
            return Context.Users.FirstOrDefault(x => x.LastName == lastName);
        }

        public UserEntity GetUserByEmail(string email)
        {
            return Context.Users.FirstOrDefault(x => x.Email == email);
        }

        public void CreateUser(string firstname, string lastname, string email)
        {
            var user = new UserEntity(lastname, firstname, email);
            Context.Users.Add(user);
        }

        public void DeleteUser(int id)
        {
            var user = GetUserById(id);
            if (user != null)
            {
                Context.Users.Remove(user);
            }
        }

        public void UpdateUser(int id, string lastname, string firstname, string email)
        {
            var user = GetUserById(id);
            if (user != null)
            {
                user.LastName = lastname;
                user.FirstName = firstname;
                user.Email = email;
            }
        }
    }
}