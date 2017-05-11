using System.Collections.Generic;

namespace FabPonto.Models
{
    public abstract class AbstractUser
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public IState WorkingState { get; set; }
        public virtual ICollection<Workday> Workdays { get; set; }
        public string Password { get; set; }

        public void ChangeWorkingState()
        {
            WorkingState.ChangeState(this);
        }
    }
}