using System.Web.UI.WebControls;

namespace FabPonto.Utils
{
    public class AuthenticateContext
    {
        private AuthenticateStrategy _strategy;

        public AuthenticateContext(AuthenticateStrategy strategy)
        {
            this._strategy = strategy;
        }

        public bool Login(string nickName, string password)
        {
            return _strategy.Login(nickName, password);
        }

        public void Logout()
        {
            _strategy.Logout();
        }
    }
}