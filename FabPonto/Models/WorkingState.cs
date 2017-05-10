namespace FabPonto.Models
{
    public class WorkingState:IState
    {
        public void ChangeState(AbstractUser user)
        {
            user.WorkingState = new NotWorkingState();
        }
    }
}