using System.Collections.Generic;

namespace FabPonto.Models
{
    public class Workday
    {
        public Workday()
        {
            this.Users = new HashSet<User>();
        }

        public int ID { get; set; }

        public int ScheduleID { get; set; }
        public int DayOfWeekID { get; set; }


        public virtual ICollection<User> Users { get; private set; }
    }
}