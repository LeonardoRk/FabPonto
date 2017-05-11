using System.Collections.Generic;

namespace FabPonto.Models
{
    public class User:IUser
    {

        public User()
        {
            this.Workdays = new HashSet<Workday>();
            WorkingState = new NotWorkingState();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public IState WorkingState { get; set; }
        public virtual ICollection<Workday> Workdays { get; private set; }
        public void ChangeWorkingState()
        {
            WorkingState.ChangeState(this);
        }
    }
}