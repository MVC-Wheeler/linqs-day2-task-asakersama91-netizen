using can.Models;
using System.ComponentModel.DataAnnotations;

namespace can.VM
{
    public class OrderVm
    {
        
        public int OrderId { get; set; }
        public DateTime OrderDateTime { get; set; }

        public int TotalPrice { get; set; }

        public string Status { get; set; } = "Requested";

        public int StaffId { get; set; }
        public int FoodItemId { get; set; }

        public int UserId { get; set; }
        public List<User> User { get; set; }
        public List<Staff >Staff { get; set; }

        public List<Fooditem> Fooditem { get; set; }
    }
}
