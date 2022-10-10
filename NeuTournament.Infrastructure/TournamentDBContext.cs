using System.Reflection;
using Microsoft.EntityFrameworkCore;
using NeuTournament.Domain.Entities;

namespace NeuTournament.Infrastructure
{
    public class TournamentDBContext : DbContext
    {
        public DbSet<TeamMember> TeamMember { get; private set; }
        public DbSet<Team> Team { get; private set; }
        public DbSet<Registration> Registration { get; private set; }
        public DbSet<Event> Event { get; private set; }

        public TournamentDBContext(DbContextOptions<TournamentDBContext> contextOptions) : base(contextOptions)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
    }
}
