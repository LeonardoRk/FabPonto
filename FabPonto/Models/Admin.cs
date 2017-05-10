using System.Collections.Generic;

namespace FabPonto.Models
{
    public sealed class Admin:AbstractUser
    {
        public Admin()
        {
            Workdays = new HashSet<Workday>();
            WorkingState = new NotWorkingState();
        }
    }
}