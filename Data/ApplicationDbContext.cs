using Microsoft.EntityFrameworkCore;
using ChessWebsite.Models;

namespace ChessWebsite.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Tournament> Tournaments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed some initial tournaments
            modelBuilder.Entity<Tournament>().HasData(
                new Tournament
                {
                    TournamentId = 1,
                    Name = "Grand Chess Championship 2024",
                    Description = "Annual championship for elite chess players with substantial prize pool",
                    StartDate = DateTime.Now.AddDays(30),
                    EndDate = DateTime.Now.AddDays(32),
                    Location = "International Convention Center",
                    MaxParticipants = 100,
                    CurrentParticipants = 45,
                    EntryFee = 500.00m,
                    Type = TournamentType.Classical,
                    TimeControl = "120+30",
                    PrizePool = 50000.00m,
                    Status = TournamentStatus.RegistrationOpen,
                    RegistrationDeadline = DateTime.Now.AddDays(25),
                    OrganizerName = "Chess Federation International",
                    ContactEmail = "championship@chessfed.org",
                    Rules = "FIDE rules apply. Minimum rating: 2000. Dress code: Formal."
                },
                new Tournament
                {
                    TournamentId = 2,
                    Name = "Blitz Battle Royale",
                    Description = "Fast-paced blitz tournament for speed chess enthusiasts",
                    StartDate = DateTime.Now.AddDays(7),
                    EndDate = DateTime.Now.AddDays(7),
                    Location = "City Chess Club",
                    MaxParticipants = 50,
                    CurrentParticipants = 32,
                    EntryFee = 25.00m,
                    Type = TournamentType.Blitz,
                    TimeControl = "3+2",
                    PrizePool = 1000.00m,
                    Status = TournamentStatus.RegistrationOpen,
                    RegistrationDeadline = DateTime.Now.AddDays(5),
                    OrganizerName = "City Chess Club",
                    ContactEmail = "events@citychessclub.com",
                    Rules = "Blitz rules. No delay. Double elimination format."
                },
                new Tournament
                {
                    TournamentId = 3,
                    Name = "Online Rapid Arena",
                    Description = "Weekly online rapid chess tournament open to all players",
                    StartDate = DateTime.Now.AddDays(3),
                    EndDate = DateTime.Now.AddDays(3),
                    Location = "Online - ChessMasters Platform",
                    MaxParticipants = 200,
                    CurrentParticipants = 178,
                    EntryFee = 10.00m,
                    Type = TournamentType.Online,
                    TimeControl = "15+10",
                    PrizePool = 2000.00m,
                    Status = TournamentStatus.Upcoming,
                    RegistrationDeadline = DateTime.Now.AddDays(2),
                    OrganizerName = "ChessMasters",
                    ContactEmail = "tournaments@chessmasters.com",
                    Rules = "Platform rules apply. Fair play monitored. No takebacks."
                }
            );
        }
    }
}