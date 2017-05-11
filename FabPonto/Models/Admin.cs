using System.Collections.Generic;

namespace FabPonto.Models
{
    public sealed class Admin:AbstractUser
    {
        public override ConcreteIterator CreateIterator()
        {
            ConcreteIterator workdaysIterator = new ConcreteIterator(this);
            return workdaysIterator;
        }

        public Admin()
        {
            Workdays = new HashSet<Workday>();
            WorkingState = new NotWorkingState();
        }
    }
}