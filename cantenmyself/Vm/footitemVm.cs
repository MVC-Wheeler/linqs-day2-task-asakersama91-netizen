using cantenmyself.Models;
using System.ComponentModel.DataAnnotations;

namespace cantenmyself.Vm
{
    public class footitemVm
    {
        [Key]
        public int FoodItemId { get; set; }
        [Required]
        public string FoodName { get; set; } = string.Empty;
        [Range(1, int.MaxValue)]
        public int Price { get; set; }

        public string Category { get; set; } = string.Empty;

        public int UserId { get; set; }

        public List<User> User { get; set; } = new List<User>();

    }
}
