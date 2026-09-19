using Microsoft.EntityFrameworkCore;

namespace cantenmyself.Models
{
    public class ApppDbContextt : DbContext
    {
        public ApppDbContextt(DbContextOptions<ApppDbContextt> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }

        public DbSet<FoodItem> FoodItems { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Staff> Staffs { get; set; }

    }
}
