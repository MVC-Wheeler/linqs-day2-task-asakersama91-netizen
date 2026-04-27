using System.ComponentModel.DataAnnotations;

namespace can.Models
{
    public class Fooditem
    {
        [Key]
        public int FoodItemId { get; set; }
        [Required]
        public string FoodName { get; set; }

        [Required]
        [Range(1,int.MaxValue)]
        public int Price { get; set; }

        [Required]
        public string Category {  get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
