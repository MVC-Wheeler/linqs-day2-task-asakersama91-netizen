using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;

namespace WebApplication5.Model
{
    public class Organizer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(99)]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [MaxLength(149)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [Phone]
        public string Phone { get; set; } = string.Empty;

        public ICollection<Event> Events { get; set; } = new List<Event>();
    }
}
