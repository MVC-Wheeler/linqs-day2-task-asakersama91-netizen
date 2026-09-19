using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;

namespace WebApplication5.Model
{
    public class Venue
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(99)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(199)]
        public string Location { get; set; } = string.Empty;

        [Required]
        [Range(1, 10000)]
        public int Capacity { get; set; }

       
        public ICollection<Event> Events { get; set; } = new List<Event>();
    }
}
