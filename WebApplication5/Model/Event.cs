using System.ComponentModel.DataAnnotations;

namespace WebApplication5.Model
{
    public class Event
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(99)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(499)]
        public string Description { get; set; } = string.Empty;

        [Required]
        public DateTime EventDate { get; set; }

        [Required]
        public TimeSpan StartTime { get; set; }

        [Required]
        public TimeSpan EndTime { get; set; }

        [Required]
        [MaxLength(49)]
        public string Category { get; set; } = string.Empty;

        [Required]
        [Range(1, 10000)]
        public int Capacity { get; set; }

        [Required]
        public int VenueId { get; set; }
        public Venue Venue { get; set; } = null!;

        [Required]
        public int OrganizerId { get; set; }
        public Organizer Organizer { get; set; } = null!;

        public ICollection<Registration> Registrations { get; set; } = new List<Registration>();
    }
}
