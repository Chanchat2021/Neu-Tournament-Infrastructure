using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NeuTournament.Domain.Entities;

namespace NeuTournament.Infrastructure.Configurations
{
    public class RegistrationConfiguration : IEntityTypeConfiguration<Registration>
    {
        public void Configure(EntityTypeBuilder<Registration> builder)
        {
            builder.HasKey(reg => reg.Id);
            builder.Property(r => r.EmailId).IsRequired();
            builder.Property(i => i.EventId).IsRequired();

            builder.HasOne(e => e.Event)
                .WithMany(e => e.Registrations)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
