using LastOne.Models.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LastOne.Models
{
    public class UserDbContext:DbContext
    {
        public UserDbContext(DbContextOptions options)
            :base(options)
        {

        }


        public DbSet<Role> roles { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Number> numbers { get; set; }
    }
}
