using ef_core2.DB_Context;
using ef_core2.Models;


using Microsoft.EntityFrameworkCore;

namespace ef_core2.DB_Context;

public class EventHubContext : DbContext
{
    public DbSet<Organizer> Organizers => Set<Organizer>();
    public DbSet<OrganizerProfile> OrganizerProfiles => Set<OrganizerProfile>();
    public DbSet<Event> Events => Set<Event>();
    public DbSet<Attendee> Attendees => Set<Attendee>();
    public DbSet<Badge> Badges => Set<Badge>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=(localdb)\\MSSQLLocalDB;Database=EventHubDb;Trusted_Connection=True;TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Organizer & Attendee  -> Data Annotations (nothing here on purpose)

        // OrganizerProfile -> Fluent API directly in OnModelCreating
        modelBuilder.Entity<OrganizerProfile>(entity =>
        {
            entity.ToTable("OrganizerProfiles");
            entity.HasKey(p => p.Id);

            entity.Property(p => p.Biography).HasMaxLength(1000);
            entity.Property(p => p.WebsiteUrl).HasMaxLength(300);
            entity.Property(p => p.LogoUrl).HasMaxLength(300);

            // Organizer (1) <-> OrganizerProfile (1)
            entity.HasOne(p => p.Organizer)
                  .WithOne(o => o.Profile)
                  .HasForeignKey<OrganizerProfile>(p => p.OrganizerId)
                  .IsRequired()
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // Event & Badge -> Fluent API in separate configuration classes
        modelBuilder.ApplyConfiguration(new EventConfiguration());
        modelBuilder.ApplyConfiguration(new BadgeConfiguration());
    }
}