using FabPonto.Models;

namespace FabPonto.Tests
{
    public class UserObjectMother
    {
        public User CreateCommomUser()
        {
            User userDefault = new User {Name = "Carson", Email = "Alexander", ID = 123 };

            // Schedule shedule = new Schedule {Starting = "08:00", Ending = "18:00"};

            return userDefault;
        }

        public Admin CreateAdmin()
        {
            Admin adminDefault = new Admin {Name = "Adney", Email = "adney@gmail", ID = 456 };

            // Schedule shedule = new Schedule {Starting = "08:00", Ending = "18:00"};

            return adminDefault;
        }
    }
}