using System.ComponentModel.DataAnnotations;

namespace schooldayOne.Models
{
    public class Department
   {
        [Key]
        public int DepartmentID { get; set; }
        [Required]
        [MaxLength(100)]
        public string DepartmentName { get; set; }
       
        [MaxLength(500)]
        public string DepartmentDescription { get; set; }

        public ICollection<Teacher> teather { get; set; }   

    }
}
