using Jokenpo.Models;
using Microsoft.EntityFrameworkCore;

namespace Jokenpo.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base (options) 
        {
            
        }

        public DbSet<Player> Players {get; set;}
        
        public DbSet<Match> Matches {get; set; }
        public DbSet<Move> Movements {get; set; }

        public DbSet<MatchMove> MatchMoves { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Move>()
                .HasMany(m => m.Winners)
                .WithMany()
                .UsingEntity<Dictionary<string, object>>(
                "MoveWinners",
                j => j.HasOne<Move>().WithMany().HasForeignKey("WinnerId").OnDelete(DeleteBehavior.Restrict),
                j => j.HasOne<Move>().WithMany().HasForeignKey("MoveId").OnDelete(DeleteBehavior.Restrict)
            );

            modelBuilder.Entity<MatchMove>()
                .HasKey(mm => new { mm.MatchId, mm.PlayerId });

            modelBuilder.Entity<MatchMove>()
                .HasOne(mm => mm.Match)
                .WithMany(m => m.MatchMoves)
                .HasForeignKey(mm => mm.MatchId);

            modelBuilder.Entity<MatchMove>()
                .HasOne(mm => mm.Player)
                .WithMany(p => p.MatchMoves)
                .HasForeignKey(mm => mm.PlayerId);

            modelBuilder.Entity<MatchMove>()
            .HasOne(mm => mm.Move)
            .WithMany()
            .HasForeignKey(mm => mm.MoveId);
        }
    }
}