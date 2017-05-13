using System;
using System.Linq;
using FabPonto.DAL;
using FabPonto.Models;

namespace FabPonto.Tests
{
    public class UserObjectMother
    {
        public static readonly Random Random = new Random();

        public User CreateCommomUser()
        {
            User userDefault = new User {Name = "Carson", Email = "Alexander", ID = 123 };
            userDefault.Workdays = GetRandomWorkdays();
            return userDefault;
        }

        public Admin CreateAdmin()
        {
            Admin adminDefault = new Admin {Name = "Adney", Email = "adney@gmail", ID = 456 };
            adminDefault.Workdays = GetRandomWorkdays();
            return adminDefault;
        }

        private Workday[] GetRandomWorkdays()
        {
            Workday[] workdays;
            using (var db = new FabContext())
            {
                workdays = db.Workdays.ToArray();
            }
            var numberOfWorkdays = Random.Next(0, workdays.Length);

            var userWorkdays = new Workday[numberOfWorkdays];
            for (var i = 0; i < numberOfWorkdays; i++)
            {
                var index = Random.Next(0, workdays.Length);
                userWorkdays[i] = workdays[index];
            }

            return userWorkdays;
        }
    }
}