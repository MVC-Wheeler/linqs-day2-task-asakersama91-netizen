using System.ComponentModel.DataAnnotations;

namespace cantenmyself.Models
{








//    - UserId: Unique identifier
//- Name: Required
//- Email: Required, valid format
//- Password: Required, more than 8 characters
//- Phone: Required, exactly 11 digits
//- Role: Admin / Customer
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]

        public string UserName { get; set; } = string.Empty;

        [Required]
        [EmailAddress(ErrorMessage ="Invalid Emali")]
        public string Email {  get; set; }= string.Empty;

        [Required]
        [MaxLength(11)]
        [MinLength(11)]
        public string Phone {  get; set; }  =string.Empty;

        [Required]
        [MinLength(9)]
        public string pasword { get; set; }=string.Empty;

        [Required]
        public string Role { get; set; }=string.Empty ;

        public List<Staff> Staffs { get; set;} = new List<Staff>();

       public List<Order> Order { get; set; }   = new List<Order>();
        public List<FoodItem>foodItems { get; set;}=new List<FoodItem>();
    }
}
