namespace DAL
{
    using System.Data.Entity;

    public class SalesContextInitializer : DropCreateDatabaseAlways<SalesContext>
    {
        protected override void Seed(SalesContext db)
        {
        }
    }
}