using System.Collections.Generic;
using FabPonto.Models;

namespace FabPonto.DAL
{
    public class FabInitializer : System.Data.Entity. DropCreateDatabaseAlways<FabContext>
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

            var daysOfWeek = new List<DayOfWeek>
            {
                new DayOfWeek{Name="Segunda"},
                new DayOfWeek{Name="Terça"},
                new DayOfWeek{Name="Quarta"}
            };

            daysOfWeek.ForEach(s => context.DaysOfWeek.Add(s));
            context.SaveChanges();

            var schedule = new List<Schedule>
            {
                new Schedule{Starting="14:00", Ending="15:00"},
                new Schedule{Starting="15:00", Ending="16:00"}
            };

            schedule.ForEach(s => context.Schedules.Add(s));
            context.SaveChanges();

            var workDays = new List<Workday>
            {
                new Workday{ScheduleID = 1, DayOfWeekID = 1},
                new Workday{ScheduleID = 2, DayOfWeekID = 1},
                new Workday{ScheduleID = 1, DayOfWeekID = 2},
                new Workday{ScheduleID = 2, DayOfWeekID = 2},
                new Workday{ScheduleID = 1, DayOfWeekID = 3},
                new Workday{ScheduleID = 2, DayOfWeekID = 3}
            };

            var abc = new Workday();



            workDays.ForEach(s => context.Workdays.Add(s));
            context.SaveChanges();
        }
    }
}