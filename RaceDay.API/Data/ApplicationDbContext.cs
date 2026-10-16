using Microsoft.EntityFrameworkCore;
using RaceDay.API.Models;

namespace RaceDay.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Organiser> Organisers { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<EventEnrollment> EventEnrollments { get; set; }
        public DbSet<Result> Results { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<EventEnrollment>().HasKey(e=>e.EnrollmentID);
            modelBuilder.Entity<Event>()
                .HasOne<Organiser>()
                .WithMany()
                .HasForeignKey(e => e.OrganiserID);

            modelBuilder.Entity<Category>()
                .HasOne<Event>()
                .WithMany()
                .HasForeignKey(c => c.EventID);

            modelBuilder.Entity<EventEnrollment>()
                .HasOne<Participant>()
                .WithMany()
                .HasForeignKey(e => e.ParticipantID);

            modelBuilder.Entity<EventEnrollment>()
                .HasOne<Event>()
                .WithMany()
                .HasForeignKey(e => e.EventID);

            modelBuilder.Entity<Result>()
                .HasOne<Participant>()
                .WithMany()
                .HasForeignKey(r => r.ParticipantID);

            modelBuilder.Entity<Result>()
                .HasOne<Event>()
                .WithMany()
                .HasForeignKey(r => r.EventID);

            modelBuilder.Entity<EventEnrollment>()
                .Property(e => e.EnrollmentDate)
                .HasDefaultValueSql("GETDATE()");
        }
    }
}