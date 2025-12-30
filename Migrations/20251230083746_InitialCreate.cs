using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Website_for_Chess.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tournaments",
                columns: table => new
                {
                    TournamentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MaxParticipants = table.Column<int>(type: "int", nullable: false),
                    CurrentParticipants = table.Column<int>(type: "int", nullable: false),
                    EntryFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    TimeControl = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PrizePool = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    RegistrationDeadline = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    OrganizerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ContactEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rules = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tournaments", x => x.TournamentId);
                });

            migrationBuilder.InsertData(
                table: "Tournaments",
                columns: new[] { "TournamentId", "ContactEmail", "CreatedDate", "CurrentParticipants", "Description", "EndDate", "EntryFee", "IsActive", "LastUpdated", "Location", "MaxParticipants", "Name", "OrganizerName", "PrizePool", "RegistrationDeadline", "Rules", "StartDate", "Status", "TimeControl", "Type" },
                values: new object[,]
                {
                    { 1, "championship@chessfed.org", new DateTime(2025, 12, 30, 16, 37, 45, 705, DateTimeKind.Local).AddTicks(1599), 45, "Annual championship for elite chess players with substantial prize pool", new DateTime(2026, 1, 31, 16, 37, 45, 705, DateTimeKind.Local).AddTicks(1615), 500.00m, true, new DateTime(2025, 12, 30, 16, 37, 45, 705, DateTimeKind.Local).AddTicks(1609), "International Convention Center", 100, "Grand Chess Championship 2024", "Chess Federation International", 50000.00m, new DateTime(2026, 1, 24, 16, 37, 45, 705, DateTimeKind.Local).AddTicks(1619), "FIDE rules apply. Minimum rating: 2000. Dress code: Formal.", new DateTime(2026, 1, 29, 16, 37, 45, 705, DateTimeKind.Local).AddTicks(1611), 1, "120+30", 5 },
                    { 2, "events@citychessclub.com", new DateTime(2025, 12, 30, 16, 37, 45, 705, DateTimeKind.Local).AddTicks(1623), 32, "Fast-paced blitz tournament for speed chess enthusiasts", new DateTime(2026, 1, 6, 16, 37, 45, 705, DateTimeKind.Local).AddTicks(1625), 25.00m, true, new DateTime(2025, 12, 30, 16, 37, 45, 705, DateTimeKind.Local).AddTicks(1623), "City Chess Club", 50, "Blitz Battle Royale", "City Chess Club", 1000.00m, new DateTime(2026, 1, 4, 16, 37, 45, 705, DateTimeKind.Local).AddTicks(1626), "Blitz rules. No delay. Double elimination format.", new DateTime(2026, 1, 6, 16, 37, 45, 705, DateTimeKind.Local).AddTicks(1624), 1, "3+2", 3 },
                    { 3, "tournaments@chessmasters.com", new DateTime(2025, 12, 30, 16, 37, 45, 705, DateTimeKind.Local).AddTicks(1628), 178, "Weekly online rapid chess tournament open to all players", new DateTime(2026, 1, 2, 16, 37, 45, 705, DateTimeKind.Local).AddTicks(1630), 10.00m, true, new DateTime(2025, 12, 30, 16, 37, 45, 705, DateTimeKind.Local).AddTicks(1628), "Online - ChessMasters Platform", 200, "Online Rapid Arena", "ChessMasters", 2000.00m, new DateTime(2026, 1, 1, 16, 37, 45, 705, DateTimeKind.Local).AddTicks(1632), "Platform rules apply. Fair play monitored. No takebacks.", new DateTime(2026, 1, 2, 16, 37, 45, 705, DateTimeKind.Local).AddTicks(1629), 0, "15+10", 6 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tournaments");
        }
    }
}
