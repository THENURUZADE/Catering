using System;
using System.Collections.Generic;
using System.Text;

namespace Catering.Core.Domain.Entities
{
    public class UserRoles
    {
        public int ID { get; set; }
        public User User { get; set; }
        public Role Role { get; set; }
    }
}
