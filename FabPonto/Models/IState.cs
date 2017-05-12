namespace FabPonto.Models
{
    public interface IState
    {
        void ChangeState(IUser user);
    }
}