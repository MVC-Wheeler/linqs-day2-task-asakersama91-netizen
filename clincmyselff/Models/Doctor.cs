namespace clincmyselff.Models
{
    public class Doctor
    {
        public int DoctorId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Specialty { get; set; } = string.Empty;


        public List<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
