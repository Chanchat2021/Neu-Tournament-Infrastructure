using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NeuTournament.Domain.Entities;

namespace NeuTournament.Infrastructure.Configurations
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.ToTable("Event").HasKey(ev => ev.Id);

            builder.Property(p => p.Name).IsRequired().HasMaxLength(20);
            builder.Property(p => p.StartDate).HasColumnType("datetime2(0)");
            builder.Property(p => p.EndDate).HasColumnType("datetime2(0)");
            builder.Property(p => p.CreatedBy).IsRequired();

            builder.HasMany(e => e.Registrations)
            .WithOne(e => e.Event)
            .HasForeignKey(e => e.EventId);

            builder.HasMany(e => e.Teams)
            .WithOne(e => e.Event)
            .HasForeignKey(e => e.EventId);
        }
    }
}
