using System.Collections.Generic;

namespace FabPonto.Models
{
    public class Admin:IUser
    {
        public ConcreteIterator CreateIterator()
        {
            ConcreteIterator workdaysIterator = new ConcreteIterator(this);
            return workdaysIterator;
        }

        public Admin()
        {
            this.Workdays = new HashSet<Workday>();
            WorkingState = new NotWorkingState();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public IState WorkingState { get; set; }
        public virtual ICollection<Workday> Workdays { get;  set; }
        public void ChangeWorkingState()
        {
            WorkingState.ChangeState(this);
        }
    }
}