using System;
using System.Collections;

namespace FabPonto.Models
{
    public class Team
    {
        private ArrayList userArray;
        private String name { get; set; }

        public Team()
        {
            userArray = new ArrayList();
        }

		public void addUser(User user)
		{
			userArray.Add(user);
		}

        public void removeUser(User user) {
            userArray.Remove(user);
        }
	}
}
