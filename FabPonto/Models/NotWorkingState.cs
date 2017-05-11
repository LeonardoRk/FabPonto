namespace FabPonto.Models
{
    public class NotWorkingState:IState
    {
        public void ChangeState(IUser user)
        {
            user.WorkingState = new WorkingState();
        }
    }
}