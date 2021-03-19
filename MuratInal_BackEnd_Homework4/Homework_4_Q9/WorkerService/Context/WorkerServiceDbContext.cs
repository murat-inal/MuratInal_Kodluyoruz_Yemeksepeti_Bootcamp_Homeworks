using Microsoft.EntityFrameworkCore;
using WorkerService.Entity;

namespace WorkerService.Context
{
    public class WorkerServiceDbContext : DbContext
    {
        public WorkerServiceDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
    }

}
