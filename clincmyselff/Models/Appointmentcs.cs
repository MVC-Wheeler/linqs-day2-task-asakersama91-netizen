namespace clincmyselff.Models
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public DateTime Date { get; set; }
        public string Notes { get; set; } = string.Empty;

        // Foreign Keys
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; } = null!;

        public int PatientId { get; set; }
        public Patient Patient { get; set; } = null!;
    }
}
