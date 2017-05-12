namespace FabPonto.Models
{
    public class WorkingState:IState
    {
        public void ChangeState(IUser user)
        {
            user.WorkingState = new NotWorkingState();
        }
    }
}