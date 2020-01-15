namespace DAL.Repositories
{
    using System.Linq;

    using DAL.Entity;
    using DAL.Repositories.Interfaces;

    public class UserRepository : GenericRepository<UserEntity, SalesContext>, IUserRepository
    {
        public UserRepository(SalesContext context)
            : base(context)
        {
        }

        public UserEntity FindByName(string lastName)
        {
            return Context.Users.FirstOrDefault(x => x.LastName == lastName);
        }
    }
}