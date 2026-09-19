using System.ComponentModel.DataAnnotations;

namespace schooldayOne.Models
{
    public class Enrollment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int StudentId { get; set; }
        public Student Student { get; set; }
      
        [Required]
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        [Required]
        public DateTime EnrollmentDate { get; set; }
        [Range(0,100)]
        public int Grade { get; set; }

    }
}
//Id int Primary key
//StudentId int Required foreign key
//SubjectId int Required foreign key
//EnrollmentDate DateTime Required
//Grade