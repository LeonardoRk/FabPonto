using System.Collections.Generic;

namespace FabPonto.Models
{
    public class Schedule
    {
        public Schedule()
        {
            this.Workdays = new HashSet<Workday>();
        }

        public int ID { get; set; }
        public string Starting { get; set; }
        public string Ending { get; set; }

        public virtual ICollection<Workday> Workdays { get; private set; }
    }
}