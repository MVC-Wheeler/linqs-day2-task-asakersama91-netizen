using System.ComponentModel.DataAnnotations;

namespace schooldayOne.Models
{
    public class Subject
    {
        [Key]
        public int SubjectId { get; set; }
        [Required]
        [StringLength(100)]
        public string SubjectName { get; set; }
        [MaxLength(500)]
        public string SubjectDescription { get; set; }

        [Required]
        [Range(0, 100)]
        public int MaxGrade{ get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}
