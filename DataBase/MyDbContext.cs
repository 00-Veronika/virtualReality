using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityFrameworkSample;

namespace EntityFrameworkSample
{
    public class MyDbContext : DbContext
    {
        public DbSet<User>Users { get; set; }
        public MyDbContext()
        {
            Users = this.Set<User>();
        }
        protected override void OnConfiguring(DbContextOptions Builder optionBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost; DataBase= VirtualRealityDb;");
        }
    }
}
