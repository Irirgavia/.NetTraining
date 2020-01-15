namespace DAL
{
    using System.Data.Entity;

    using DAL.Entity;

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

        public DbSet<ProductEntity> Products { get; set; }

        public DbSet<SaleEntity> Sales { get; set; }

        public DbSet<UserEntity> Users { get; set; }

        public DbSet<RecordFileEntity> RecordFiles { get; set; }
    }
}
