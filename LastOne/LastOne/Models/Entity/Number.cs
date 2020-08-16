using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LastOne.Models.Entity
{
    public class Number:BaseEntity
    {
        public string phoneNumber { get; set; }
        public int UserId { get; set; }
        public virtual User user { get; set; }
    }
}
