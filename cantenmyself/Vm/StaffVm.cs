using cantenmyself.Models;
using System.ComponentModel.DataAnnotations;

namespace cantenmyself.Vm
{
    public class StaffVm
    {
        [Key]
        public int StaffId { get; set; }
        [Required]
        public string StaffName { get; set; } = string.Empty;
        [Required]
        [MaxLength(11)]
        [MinLength(11)]

        public string phone { get; set; } = string.Empty;

        [Required]
        public string Status { get; set; } = string.Empty;

        public int UserId { get; set; }

        public List<User >User { get; set; }=new List<User>();
    }
}
