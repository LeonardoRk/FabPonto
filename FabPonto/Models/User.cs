﻿using System.Collections.Generic;

namespace FabPonto.Models
{
    public class User
    {
        public User()
        {
            this.Workdays = new HashSet<Workday>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Workday> Workdays { get; private set; }
    }
}