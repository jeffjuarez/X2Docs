using DataLayer.Mapping;
using Repository;
using System.Data.Entity;

namespace DataLayer
{
    public class DrakeContext : DbContextBase, IDbContext
    {
        public DrakeContext() :
            base("DrakeConnection")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DrakeContext, DataLayer.Migrations.Configuration>("DrakeConnection"));
        }

        public new DbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new FileUploadMap());
        }
    }
}
