using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserRegistration.Data.Entity;

namespace UserRegistration.Data.Context
{
    public class UsersDbContext : DbContext
    {

        public UsersDbContext(DbContextOptions<UsersDbContext> options)
            :base(options)
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
