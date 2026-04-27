using System.ComponentModel.DataAnnotations;

namespace can.Models
{
  
    public class User
    {
        [Key]
       public int UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [EmailAddress(ErrorMessage ="invalid email")]
        public string Email {  get; set; }
        [Required]
        [MaxLength(11)]
        [MinLength(11)]
        public string phone {  get; set; }
        [Required]
        public string Role {  get; set; }

        public List<Fooditem> Fooditems { get; set; } = new List<Fooditem>();
        public List<Staff> staffs { get; set; } = new List<Staff>();
        public List<Order> oreders { get; set; } = new List<Order>();


    }
}
