using System.ComponentModel.DataAnnotations;

namespace schooldayOne.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; } // Primary Key

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        public int ClassRoomId { get; set; } 
        public ClassRoom ClassRoom { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
   
    }
}
