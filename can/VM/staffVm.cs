using can.Models;
using System.ComponentModel.DataAnnotations;

namespace can.VM
{
    public class staffVm
    {
        public int StaffId { get; set; }
        public string StaffName { get; set; } = string.Empty;
        public string JobTitle { get; set; }
        [Required]
        [MaxLength(11, ErrorMessage = "must be 11")]
        [MinLength(11, ErrorMessage = "must be 11")]
        public string phone { get; set; }
        public string Status { get; set; }
        public int UserId { get; set; }
        public List <User> User { get; set; }=new List<User>(); 
    }
}
