namespace DAL.Repositories
{
    using System.Linq;

    using BLEntity;

    using DAL.Repositories.Interfaces;

    public class UserRepository : GenericRepository<User, SalesContext>, IUserRepository
    {
        public UserRepository(SalesContext context)
            : base(context)
        {
        }

        public User FindByName(string lastName)
        {
            return Context.Users.FirstOrDefault(x => x.LastName == lastName);
        }
    }
}