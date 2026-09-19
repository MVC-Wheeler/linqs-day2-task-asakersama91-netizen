using Microsoft.EntityFrameworkCore;
using WebApplication5.Model;

namespace WebApplication5.DbContexxt
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Event> Events => Set<Event>();
        public DbSet<Organizer> Organizers => Set<Organizer>();
        public DbSet<Venue> Venues => Set<Venue>();
        public DbSet<Attendee> Attendees => Set<Attendee>();
        public DbSet<Registration> Registrations => Set<Registration>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // --- Unique Constraints ---
            modelBuilder.Entity<Organizer>().HasIndex(o => o.Email).IsUnique();
            modelBuilder.Entity<Attendee>().HasIndex(a => a.Email).IsUnique();
            modelBuilder.Entity<Venue>().HasIndex(v => v.Name).IsUnique();

            // --- Duplicate Registration Prevention (Composite Unique Constraint) ---
            modelBuilder.Entity<Registration>()
                .HasIndex(r => new { r.EventId, r.AttendeeId })
                .IsUnique();

            // --- Relationships & Delete Behaviors ---
            modelBuilder.Entity<Event>()
                .HasOne(e => e.Organizer)
                .WithMany(o => o.Events)
                .HasForeignKey(e => e.OrganizerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Event>()
                .HasOne(e => e.Venue)
                .WithMany(v => v.Events)
                .HasForeignKey(e => e.VenueId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Registration>()
                .HasOne(r => r.Event)
                .WithMany(e => e.Registrations)
                .HasForeignKey(r => r.EventId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Registration>()
                .HasOne(r => r.Attendee)
                .WithMany(a => a.Registrations)
                .HasForeignKey(r => r.AttendeeId)
                .OnDelete(DeleteBehavior.Cascade);

            // --- Data Seeding ---
            modelBuilder.Entity<Organizer>().HasData(
                new Organizer { Id = 1, FullName = "Ahmed Ali", Email = "ahmed.ali@example.com", Phone = "+201000000001" },
                new Organizer { Id = 2, FullName = "Mona Mohamed", Email = "mona.mohamed@example.com", Phone = "+201000000002" },
                new Organizer { Id = 3, FullName = "Khaled Hassan", Email = "khaled.hassan@example.com", Phone = "+201000000003" }
            );

            modelBuilder.Entity<Venue>().HasData(
                new Venue { Id = 1, Name = "Cairo Conference Center", Location = "Cairo, Egypt", Capacity = 5000 },
                new Venue { Id = 2, Name = "Alexandria Library Hall", Location = "Alexandria, Egypt", Capacity = 1500 },
                new Venue { Id = 3, Name = "Smart Village Arena", Location = "Giza, Egypt", Capacity = 3000 }
            );

            modelBuilder.Entity<Event>().HasData(
                new Event { Id = 1, Title = "Tech Summit 2026", Description = "Annual technology conference.", EventDate = new DateTime(2026, 10, 10), StartTime = new TimeSpan(9, 0, 0), EndTime = new TimeSpan(17, 0, 0), Category = "Technology", Capacity = 500, VenueId = 1, OrganizerId = 1 },
                new Event { Id = 2, Title = "AI Workshop", Description = "Hands-on AI training.", EventDate = new DateTime(2026, 11, 12), StartTime = new TimeSpan(10, 0, 0), EndTime = new TimeSpan(14, 0, 0), Category = "Education", Capacity = 100, VenueId = 3, OrganizerId = 2 },
                new Event { Id = 3, Title = "Startup Pitch Day", Description = "Pitching to investors.", EventDate = new DateTime(2026, 12, 5), StartTime = new TimeSpan(11, 0, 0), EndTime = new TimeSpan(18, 0, 0), Category = "Business", Capacity = 300, VenueId = 2, OrganizerId = 3 },
                new Event { Id = 4, Title = "Web Dev Bootcamp", Description = "Learn modern web frameworks.", EventDate = new DateTime(2026, 9, 25), StartTime = new TimeSpan(9, 0, 0), EndTime = new TimeSpan(16, 0, 0), Category = "Technology", Capacity = 200, VenueId = 3, OrganizerId = 1 },
                new Event { Id = 5, Title = "Cyber Security Seminar", Description = "Protecting enterprise data.", EventDate = new DateTime(2026, 10, 20), StartTime = new TimeSpan(13, 0, 0), EndTime = new TimeSpan(17, 0, 0), Category = "Security", Capacity = 250, VenueId = 1, OrganizerId = 2 }
            );

            modelBuilder.Entity<Attendee>().HasData(
                new Attendee { Id = 1, FullName = "Omar Youssef", Email = "omar.youssef@example.com", Phone = "+201111111111" },
                new Attendee { Id = 2, FullName = "Salma Khaled", Email = "salma.khaled@example.com", Phone = "+201111111122" },
                new Attendee { Id = 3, FullName = "Tamer Hosny", Email = "tamer.hosny@example.com", Phone = "+201111111133" },
                new Attendee { Id = 4, FullName = "Nourhan Adel", Email = "nourhan.adel@example.com", Phone = "+201111111144" },
                new Attendee { Id = 5, FullName = "Karim Mahmoud", Email = "karim.mahmoud@example.com", Phone = "+201111111155" },
                new Attendee { Id = 6, FullName = "Dina Samir", Email = "dina.samir@example.com", Phone = "+201111111166" }
            );

            modelBuilder.Entity<Registration>().HasData(
                new Registration { Id = 1, RegistrationDate = new DateTime(2026, 8, 1), Status = "Confirmed", EventId = 1, AttendeeId = 1 },
                new Registration { Id = 2, RegistrationDate = new DateTime(2026, 8, 2), Status = "Confirmed", EventId = 1, AttendeeId = 2 },
                new Registration { Id = 3, RegistrationDate = new DateTime(2026, 8, 3), Status = "Pending", EventId = 2, AttendeeId = 3 },
                new Registration { Id = 4, RegistrationDate = new DateTime(2026, 8, 4), Status = "Confirmed", EventId = 2, AttendeeId = 4 },
                new Registration { Id = 5, RegistrationDate = new DateTime(2026, 8, 5), Status = "Confirmed", EventId = 3, AttendeeId = 5 },
                new Registration { Id = 6, RegistrationDate = new DateTime(2026, 8, 6), Status = "Cancelled", EventId = 4, AttendeeId = 6 },
                new Registration { Id = 7, RegistrationDate = new DateTime(2026, 8, 7), Status = "Confirmed", EventId = 4, AttendeeId = 1 },
                new Registration { Id = 8, RegistrationDate = new DateTime(2026, 8, 8), Status = "Confirmed", EventId = 5, AttendeeId = 2 }
            );
        }
    }
