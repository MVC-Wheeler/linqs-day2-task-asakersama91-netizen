using cantenmyself.Models;
using System.ComponentModel.DataAnnotations;

namespace cantenmyself.Vm
{
    public class OrderVm
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime OrderDateTime { get; set; }
        [Required]
        public string Status { get; set; } = string.Empty;

        public int StaffId { get; set; }
        public int FoodItemId { get; set; }

        public int UserId { get; set; }

        public List<User> User { get; set; } = new List<User>();

        public List<Staff> Staff { get; set; } = new List<Staff>();

        public List<FoodItem> FoodItem { get; set; }= new List<FoodItem>();

    }
}
