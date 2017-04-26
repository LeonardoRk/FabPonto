using System.Collections.Generic;

namespace FabPonto.Models
{
    public class DayOfWeek
    {
        public DayOfWeek()
        {
            this.Workdays = new HashSet<Workday>();
        }
        public int ID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Workday> Workdays { get; private set; }

    }
}