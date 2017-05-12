using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using FabPonto.Models;

namespace FabPonto.DAL
{
    public class FabContext: DbContext
    {
        private const string DATABASE_NAME = "FabContext";
        private static FabContext databaseInstance = null;
        private static object myLock = new object();

        private FabContext() : base(DATABASE_NAME)
        {
        }

        public static FabContext GetFabContextInstance()
        {

            if (databaseInstance == null)
            {
                lock (myLock)
                {
                    if (databaseInstance == null)
                    {
                        databaseInstance = new FabContext();
                    }
                    else
                    {
                        //nothing to do
                    }
                }
            }
            else
            {
                // nothing to do
            }
            return databaseInstance;
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