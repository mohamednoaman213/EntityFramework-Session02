
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ef_core2.Models;
namespace ef_core2.DB_Context;

public class BadgeConfiguration : IEntityTypeConfiguration<Badge>
{
    public void Configure(EntityTypeBuilder<Badge> builder)
    {
        builder.ToTable("Badges");
        builder.HasKey(b => b.Id);

        builder.Property(b => b.BadgeNumber)
               .IsRequired()
               .HasMaxLength(50);

        builder.HasIndex(b => b.BadgeNumber).IsUnique();

        builder.Property(b => b.IssuedDate).IsRequired();

        // Store the tier as text ("Standard" / "VIP")
        builder.Property(b => b.Tier)
               .IsRequired()
               .HasConversion<string>()
               .HasMaxLength(20);

        // Attendee (1) <-> Badge (0..1)
        builder.HasOne(b => b.Attendee)
               .WithOne(a => a.Badge)
               .HasForeignKey<Badge>(b => b.AttendeeId)
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade);
    }
}
