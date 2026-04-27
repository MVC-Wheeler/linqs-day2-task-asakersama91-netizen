using System.ComponentModel.DataAnnotations;
namespace can.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public DateTime OrderDateTime { get; set; }

        [Range (1,int.MaxValue)]
        public int TotalPrice { get; set; }

        public string Status { get; set; } = "Requested";

        public int StaffId { get; set; }
        public int FoodItemId { get; set; } 

        public int UserId { get; set; }

        public User User { get; set; }
        public Staff Staff { get; set; }

        public Fooditem Fooditem { get; set; }  
    }
}
