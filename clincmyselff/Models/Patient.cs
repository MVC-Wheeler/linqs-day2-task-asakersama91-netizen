using System.ComponentModel.DataAnnotations;

namespace clincmyselff.Models
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }

        public List<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
