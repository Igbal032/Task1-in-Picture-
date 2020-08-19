using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static LastTask.Models.Identity;

namespace LastTask.Models.DataContext
{
    public class UserDbContext:IdentityDbContext<PromediUser,PromediRole,int>
    {
        public UserDbContext(DbContextOptions options)
            :base(options)
        {
                
        }
        public DbSet<Number> numbers { get; set; }
    }
}
