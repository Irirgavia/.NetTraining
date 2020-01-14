namespace DAL
{
    using System.Data.Entity;

    using BLEntity;

    public class SalesContext : DbContext
    {
        static SalesContext()
        {
            Database.SetInitializer<SalesContext>(new SalesContextInitializer());
        }

        public SalesContext()
            : base("SalesContext")
        {
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Sale> Sales { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<RecordFile> RecordFiles { get; set; }
    }
}
