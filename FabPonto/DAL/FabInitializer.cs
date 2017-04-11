using System.Collections.Generic;
using FabPonto.Models;

namespace FabPonto.DAL
{
    public class FabInitializer : System.Data.Entity. DropCreateDatabaseIfModelChanges<FabContext>
    {
        protected override void Seed(FabContext context)
        {
            var users = new List<User>
            {
                new User{Name= "Carson",Email= "Alexander"},
                new User{Name="Meredith",Email="Alonso"},
                new User{Name="Arturo",Email="Anand"},
                new User{Name="Gytis",Email="Barzdukas"},
                new User{Name="Yan",Email="Li"}
            };

            users.ForEach(s => context.Users.Add(s));
            context.SaveChanges();
        }
    }
}