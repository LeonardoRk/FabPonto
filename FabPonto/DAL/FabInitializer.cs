using System.Collections.Generic;
using FabPonto.Models;

namespace FabPonto.DAL
{
    public class FabInitializer : System.Data.Entity. DropCreateDatabaseIfModelChanges<FabContext>
    {
        protected override void Seed(FabContext context)
        {
//            var users = new List<User>
//            {
//                new User{Name= "Carson",Email= "Alexander"},
//                new User{Name="Meredith",Email="Alonso"},
//                new User{Name="Arturo",Email="Anand"},
//                new User{Name="Gytis",Email="Barzdukas"},
//                new User{Name="Yan",Email="Li"}
//            };
//
//            users.ForEach(s => context.Users.Add(s));
//            context.SaveChanges();

            var daysOfWeek = new List<DayOfWeek>
            {
                new DayOfWeek{Name="Segunda"},
                new DayOfWeek{Name="Terça"},
                new DayOfWeek{Name="Quarta"},
                new DayOfWeek{Name="Quinta"},
                new DayOfWeek{Name="Sexta"},
                new DayOfWeek{Name="Sábado"}

            };

            daysOfWeek.ForEach(s => context.DaysOfWeek.Add(s));
            context.SaveChanges();

            var schedule = new List<Schedule>
            {
                new Schedule{Starting="08:00", Ending="09:00"},
                new Schedule{Starting="09:00", Ending="10:00"},
                new Schedule{Starting="10:00", Ending="11:00"},
                new Schedule{Starting="11:00", Ending="12:00"},
                new Schedule{Starting="12:00", Ending="13:00"},
                new Schedule{Starting="13:00", Ending="14:00"},
                new Schedule{Starting="14:00", Ending="15:00"},
                new Schedule{Starting="15:00", Ending="16:00"},
                new Schedule{Starting="16:00", Ending="17:00"},
                new Schedule{Starting="17:00", Ending="18:00"},
                new Schedule{Starting="18:00", Ending="19:00"}
            };

            schedule.ForEach(s => context.Schedules.Add(s));
            context.SaveChanges();

            var workDays = new List<Workday>
            {
                new Workday{ScheduleID = 1, DayOfWeekID = 1},
                new Workday{ScheduleID = 2, DayOfWeekID = 1},
                new Workday{ScheduleID = 3, DayOfWeekID = 1},
                new Workday{ScheduleID = 4, DayOfWeekID = 1},
                new Workday{ScheduleID = 5, DayOfWeekID = 1},
                new Workday{ScheduleID = 6, DayOfWeekID = 1},
                new Workday{ScheduleID = 7, DayOfWeekID = 1},
                new Workday{ScheduleID = 8, DayOfWeekID = 1},
                new Workday{ScheduleID = 9, DayOfWeekID = 1},
                new Workday{ScheduleID = 10, DayOfWeekID = 1},
                new Workday{ScheduleID = 11, DayOfWeekID = 1},
                new Workday{ScheduleID = 1, DayOfWeekID = 2},
                new Workday{ScheduleID = 2, DayOfWeekID = 2},
                new Workday{ScheduleID = 3, DayOfWeekID = 2},
                new Workday{ScheduleID = 4, DayOfWeekID = 2},
                new Workday{ScheduleID = 5, DayOfWeekID = 2},
                new Workday{ScheduleID = 6, DayOfWeekID = 2},
                new Workday{ScheduleID = 7, DayOfWeekID = 2},
                new Workday{ScheduleID = 8, DayOfWeekID = 2},
                new Workday{ScheduleID = 9, DayOfWeekID = 2},
                new Workday{ScheduleID = 10, DayOfWeekID = 2},
                new Workday{ScheduleID = 11, DayOfWeekID = 2},
                new Workday{ScheduleID = 1, DayOfWeekID = 3},
                new Workday{ScheduleID = 2, DayOfWeekID = 3},
                new Workday{ScheduleID = 3, DayOfWeekID = 3},
                new Workday{ScheduleID = 4, DayOfWeekID = 3},
                new Workday{ScheduleID = 5, DayOfWeekID = 3},
                new Workday{ScheduleID = 6, DayOfWeekID = 3},
                new Workday{ScheduleID = 7, DayOfWeekID = 3},
                new Workday{ScheduleID = 8, DayOfWeekID = 3},
                new Workday{ScheduleID = 9, DayOfWeekID = 3},
                new Workday{ScheduleID = 10, DayOfWeekID = 3},
                new Workday{ScheduleID = 11, DayOfWeekID = 3},
                new Workday{ScheduleID = 1, DayOfWeekID = 4},
                new Workday{ScheduleID = 2, DayOfWeekID = 4},
                new Workday{ScheduleID = 3, DayOfWeekID = 4},
                new Workday{ScheduleID = 4, DayOfWeekID = 4},
                new Workday{ScheduleID = 5, DayOfWeekID = 4},
                new Workday{ScheduleID = 6, DayOfWeekID = 4},
                new Workday{ScheduleID = 7, DayOfWeekID = 4},
                new Workday{ScheduleID = 8, DayOfWeekID = 4},
                new Workday{ScheduleID = 9, DayOfWeekID = 4},
                new Workday{ScheduleID = 10, DayOfWeekID = 4},
                new Workday{ScheduleID = 11, DayOfWeekID = 4},
                new Workday{ScheduleID = 1, DayOfWeekID = 5},
                new Workday{ScheduleID = 2, DayOfWeekID = 5},
                new Workday{ScheduleID = 3, DayOfWeekID = 5},
                new Workday{ScheduleID = 4, DayOfWeekID = 5},
                new Workday{ScheduleID = 5, DayOfWeekID = 5},
                new Workday{ScheduleID = 6, DayOfWeekID = 5},
                new Workday{ScheduleID = 7, DayOfWeekID = 5},
                new Workday{ScheduleID = 8, DayOfWeekID = 5},
                new Workday{ScheduleID = 9, DayOfWeekID = 5},
                new Workday{ScheduleID = 10, DayOfWeekID = 5},
                new Workday{ScheduleID = 11, DayOfWeekID = 5},
                new Workday{ScheduleID = 1, DayOfWeekID = 6},
                new Workday{ScheduleID = 2, DayOfWeekID = 6},
                new Workday{ScheduleID = 3, DayOfWeekID = 6},
                new Workday{ScheduleID = 4, DayOfWeekID = 6},
                new Workday{ScheduleID = 5, DayOfWeekID = 6},
                new Workday{ScheduleID = 6, DayOfWeekID = 6},
                new Workday{ScheduleID = 7, DayOfWeekID = 6},
                new Workday{ScheduleID = 8, DayOfWeekID = 6},
                new Workday{ScheduleID = 9, DayOfWeekID = 6},
                new Workday{ScheduleID = 10, DayOfWeekID = 6},
                new Workday{ScheduleID = 11, DayOfWeekID = 6}
            };

            workDays.ForEach(s => context.Workdays.Add(s));
            context.SaveChanges();
        }
    }
}