namespace ClincMyself.Models
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public DateTime Date { get; set; }
        public string Notes { get; set; } = string.Empty;

        // fk
        public int DoctorId;
        public Doctorcs Doctorcs { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }    


    }
}
