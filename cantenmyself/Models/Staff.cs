using System.ComponentModel.DataAnnotations;

namespace cantenmyself.Models
{
//    - StaffId: Unique identifier
//- Name: Required
//- JobTitle: Chef / Cashier / Server
//- Phone: Required, exactly 11 digits
//- Status: Available / Busy
//- CreatedByUserId: Admin who added the staff
    public class Staff
    {
        [Key]
        public int StaffId { get; set; }
        [Required]
        public string StaffName { get; set; }=string.Empty;
        [Required]
        [MaxLength(11)]
        [MinLength(11)]

        public string phone {  get; set; }=string.Empty;

        [Required]
        public string Status {  get; set; }=string.Empty;

        public int UserId { get; set; } 

        public User User { get; set; }

        public List<Order> Orders { get; set; } = new List<Order>();


    }
}
