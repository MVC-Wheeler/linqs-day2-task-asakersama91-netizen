using System.ComponentModel.DataAnnotations;

namespace cantenmyself.Models
{
    //     FoodItemId: Unique identifier
    //- Name: Required
    //- Price: Must be greater than 0
    //- Category: Meal / Drink / Snack
    //- CreatedByUserId: Admin who created it
    public class FoodItem
    {
        [Key]
        public int FoodItemId { get; set; }
        [Required]
        public string FoodName { get; set; } = string.Empty;
        [Range(1, int.MaxValue)]
        public int Price { get; set; }

        public string Category { get; set; } = string.Empty;

        public int UserId { get; set; }

        public User User { get; set; }  

        public List<Order>orders { get; set; }
    }
}
