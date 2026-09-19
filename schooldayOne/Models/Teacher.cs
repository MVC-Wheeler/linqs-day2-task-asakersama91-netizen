using System.ComponentModel.DataAnnotations;

namespace schooldayOne.Models
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        [MaxLength(150)]
        public string Email { get; set; }

        [MaxLength(20)]
        public string Phone { get; set; }

        [Required]
        [Range(0,double.MaxValue)]
        public decimal Salary { get; set; }

        public ICollection <Subject> Subjects { get; set; }


        public int DepartmentID { get; set; }
        public Department Department { get; set; }


    }
}
