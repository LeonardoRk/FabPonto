using System;

namespace FabPonto.Controllers
{
    public class WorktimeRegisterController
    {
        private string getCurrentTime()
        {
            String currentTime = DateTime.Now.ToString("h:mm:ss tt");
            return currentTime;
        }


    }
}