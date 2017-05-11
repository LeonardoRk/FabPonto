using System.Collections.Generic;

namespace FabPonto.Models
{
    public sealed class User:AbstractUser
    {
        private IIterator workdayIterator = null;

        public override ConcreteIterator CreateIterator()
        {
            ConcreteIterator workdaysIterator = new ConcreteIterator(this);
            return workdaysIterator;
        }

        public User()
        {
            Workdays = new HashSet<Workday>();
            WorkingState = new NotWorkingState();
        }

    }
}