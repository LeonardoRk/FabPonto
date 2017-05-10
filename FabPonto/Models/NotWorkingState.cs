namespace FabPonto.Models
{
    public class NotWorkingState:IState
    {
        public void ChangeState(AbstractUser user)
        {
            user.WorkingState = new WorkingState();
        }
    }
}