using System.Collections.Generic;

namespace FabPonto.Models
{
    public sealed class User:AbstractUser
    {
        public User()
        {
            Workdays = new HashSet<Workday>();
            WorkingState = new NotWorkingState();
        }

    }
}