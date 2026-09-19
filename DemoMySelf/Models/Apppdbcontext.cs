using Microsoft.EntityFrameworkCore;

namespace DemoMySelf.Models
{
    public class Apppdbcontext : DbContext
    {
        public Apppdbcontext(DbContextOptions <Apppdbcontext > options) : base(options)
        {
        }

        public DbSet<Order> orders { get; set; }    
        public DbSet<MenuItem> menuItems { get; set; }

        public DbSet<Categorycs> categories { get; set; }

    }
}
