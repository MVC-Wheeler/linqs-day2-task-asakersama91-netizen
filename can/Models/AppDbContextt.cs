using can.VM;
using Microsoft.EntityFrameworkCore;

namespace can.Models
{
    public class AppDbContextt : DbContext
    {
        public AppDbContextt(DbContextOptions<AppDbContextt> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Fooditem> Fooditems { get; set; }

        public DbSet<Order> orders { get; set; }

        public DbSet<Staff> staffs { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fooditem>().HasOne(e => e.User).WithMany(t => t.Fooditems).HasForeignKey(e=>e.UserId).OnDelete(DeleteBehavior.Cascade);


        }

    }
}
