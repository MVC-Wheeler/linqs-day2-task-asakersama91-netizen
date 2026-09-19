using System.ComponentModel.DataAnnotations;

namespace schooldayOne.Models
{
    public class ClassRoom
    {
        [Key]
        public int ClassRoomId { get; set; }
        [Required]
        [MaxLength(50)]
        public string ClassRoomName { get; set; }
        [Required]
        [Range(1,12)]
        public int ClassLevel { get; set; }
        [Required]
        [Range(1,100)]
        public int Capacity { get; set; } 
        public ICollection<Student> Students { get; set; }
    }
}
//Property Data Type Validation Rules
//Id int Primary key
//Name string Required, maximum length 50, cannot be

//empty

//GradeLevel int Required, value between 1 and 12
//Capacity