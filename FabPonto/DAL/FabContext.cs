using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using FabPonto.Models;

namespace FabPonto.DAL
{
    public class FabContext: DbContext
    {
        public FabContext(): base("FabContext")
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}