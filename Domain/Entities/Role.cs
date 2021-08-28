﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Role : Entity
    {
        public virtual ICollection<User> Users { get; set; } = new HashSet<User>();
    }
}
