namespace DAL
{
    using System.Data.Entity;

    using DAL.Entity;

    public class SalesContextInitializer : DropCreateDatabaseIfModelChanges<SalesContext>
    {
        protected override void Seed(SalesContext db)
        {
            UserEntity user = new UserEntity("user", "anastasiya", "kramushchenka", "mail.com");
            db.Users.Add(user);
            db.SaveChanges();
        }
    }
}