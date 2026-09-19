using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http.HttpResults;

namespace cantenmyself.Models
{
//    - OrderId: Unique identifier
//- OrderDateTime: Required
//- TotalPrice: Must be greater than 0
//- Status: Requested / Preparing / Ready / Completed / Cancelled
//- StaffId: Assigned staff
//- FoodItemId: Selected item
//- UserId: Customer who made the order


    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime OrderDateTime { get; set; }
        [Required]
        public string Status {  get; set; }=string.Empty;

        public int StaffId { get; set; }
        public int FoodItemId { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public Staff Staff { get; set; } 

        public FoodItem FoodItem { get; set; } 



    }
}
