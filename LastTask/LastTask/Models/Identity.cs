using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LastTask.Models
{
    public class Identity
    {
        public class PromediUser:IdentityUser<int>
        {
            public string FatherName { get; set; }
            public int NumberId { get; set; }
            public virtual Number number { get; set; }
        }
        public class PromediRole:IdentityRole<int>
        { 
        
        }
    }
}
