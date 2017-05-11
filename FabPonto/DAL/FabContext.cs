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

        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<DayOfWeek> DaysOfWeek { get; set; }
        public DbSet<Workday> Workdays { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}