using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace FabPonto.Models
{
    public abstract class AbstractUser
    {
        public int ID { get; set; }
        [Index(IsUnique=true)]
        public string NickName { get; set; }
        public string Name { get; set; }
        [Index(IsUnique=true)]
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