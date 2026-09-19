namespace ClincMyself.Models
{
    public class Doctorcs
    {
        public int DoctorId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Specialty { get; set; } = string.Empty;


        public List<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
