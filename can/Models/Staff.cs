using System.ComponentModel.DataAnnotations;

namespace can.Models
{
  
    public class Staff
    {
        [Key]
        public int StaffId { get; set; }
        [Required]
        public string StaffName { get; set; } = string.Empty;

        [Required]
        public string JobTitle {  get; set; } 

        [Required]
        [MaxLength(11,ErrorMessage ="must be 11")]
        [MinLength(11, ErrorMessage = "must be 11")]
        public string phone { get; set; }
        [Required]
        public string Status { get; set; }

        public int UserId { get; set; }
         public User User { get; set; }

    }
}
