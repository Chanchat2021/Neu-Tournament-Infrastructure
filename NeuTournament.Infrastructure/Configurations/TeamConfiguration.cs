using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NeuTournament.Domain.Entities;

namespace NeuTournament.Infrastructure.Configurations
{
    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name).IsRequired().HasMaxLength(20);
            builder.Property(t => t.CreatedBy).IsRequired();

            builder.Property(t => t.Name).IsRequired().HasMaxLength(20);
            builder.Property(t => t.CreatedBy).IsRequired();

            builder.HasMany(e => e.TeamMembers)
            .WithOne(e => e.Team)
            .HasForeignKey(e => e.TeamId);

        }
    }
}
