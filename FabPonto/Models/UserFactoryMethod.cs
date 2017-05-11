using System.ComponentModel;

namespace FabPonto.Models
{
    public class UserFactoryMethod
    {
        public const int NormalUser = 0;
        public const int AdminUser = 1;

        public IUser FactoryUser(int userType)
        {
            IUser user;

            switch (userType)
            {
                case NormalUser:
                    user = new User();
                    break;
                case AdminUser:
                    user = new Admin();
                    break;
                default:
                    throw new InvalidEnumArgumentException("Invalid user type");
            }

            return user;
        }

    }
}