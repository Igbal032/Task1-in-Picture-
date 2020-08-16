using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LastOne.Models.Entity
{
    public class User:BaseEntity
    {
        public string UserName { get; set; }
        public string FatherName { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}
