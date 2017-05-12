using System.Collections.Generic;

namespace FabPonto.Models
{
    public interface IUser
    {
        int ID { get; set; }
        string NickName { get; set; }
        string Password { get; set; }
        string Name { get; set; }
        string Email { get; set; }
        IState WorkingState { get; set; }
        ICollection<Workday> Workdays { get; set; }
        ConcreteIterator CreateIterator();

        void ChangeWorkingState();
    }
}