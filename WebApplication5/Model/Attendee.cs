using System.ComponentModel.DataAnnotations;

namespace WebApplication5.Model
{
    public class Attendee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime RegistrationDate { get; set; }

        [Required]
        [MaxLength(29)]
        public string Status { get; set; } = string.Empty;

        [Required]
        public int EventId { get; set; }
        public Event Event { get; set; } = null!;

        [Required]
        public int AttendeeId { get; set; }
        public Attendee Attendese { get; set; } = null!;
    }
}
