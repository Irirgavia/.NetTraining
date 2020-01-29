namespace DAL.Repositories
{
    using System.Linq;

    using DAL.Entity;
    using DAL.Repositories.Interfaces;

    public class UserSaleRepository : GenericRepository<UserEntity, SalesContext>, IUserSaleRepository
    {
        public UserSaleRepository(SalesContext context)
            : base(context)
        {
        }

        public UserEntity FindByName(string lastName)
        {
            return Context.Users.FirstOrDefault(x => x.LastName == lastName);
        }
    }
}