using System.Collections.Generic;

namespace FabPonto.Models
{
    public class Workday
    {
        public Workday()
        {
            this.Users = new HashSet<User>();
            this.Admins = new HashSet<Admin>();

        }

        public int ID { get; set; }

        public int ScheduleID { get; set; }
        public int DayOfWeekID { get; set; }

        public int GetDayOfWeekId()
        {
            return this.DayOfWeekID;
        }


        public virtual ICollection<User> Users { get; private set; }
        public virtual ICollection<Admin> Admins { get; private set; }

    }
}