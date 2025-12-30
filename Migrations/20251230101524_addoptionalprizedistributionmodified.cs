using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Website_for_Chess.Migrations
{
    /// <inheritdoc />
    public partial class addoptionalprizedistributionmodified : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PrizeDistribution");

            migrationBuilder.DropColumn(
                name: "TotalPrizePool",
                table: "Tournaments");

            migrationBuilder.AddColumn<decimal>(
                name: "PrizePool",
                table: "Tournaments",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Tournaments",
                keyColumn: "TournamentId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "EndDate", "LastUpdated", "PrizePool", "RegistrationDeadline", "StartDate" },
                values: new object[] { new DateTime(2025, 12, 30, 18, 15, 24, 184, DateTimeKind.Local).AddTicks(5227), new DateTime(2026, 1, 31, 18, 15, 24, 184, DateTimeKind.Local).AddTicks(5243), new DateTime(2025, 12, 30, 18, 15, 24, 184, DateTimeKind.Local).AddTicks(5236), 50000.00m, new DateTime(2026, 1, 24, 18, 15, 24, 184, DateTimeKind.Local).AddTicks(5249), new DateTime(2026, 1, 29, 18, 15, 24, 184, DateTimeKind.Local).AddTicks(5238) });

            migrationBuilder.UpdateData(
                table: "Tournaments",
                keyColumn: "TournamentId",
                keyValue: 2,
                columns: new[] { "CreatedDate", "EndDate", "LastUpdated", "PrizePool", "RegistrationDeadline", "StartDate" },
                values: new object[] { new DateTime(2025, 12, 30, 18, 15, 24, 184, DateTimeKind.Local).AddTicks(5254), new DateTime(2026, 1, 6, 18, 15, 24, 184, DateTimeKind.Local).AddTicks(5256), new DateTime(2025, 12, 30, 18, 15, 24, 184, DateTimeKind.Local).AddTicks(5255), 1000.00m, new DateTime(2026, 1, 4, 18, 15, 24, 184, DateTimeKind.Local).AddTicks(5258), new DateTime(2026, 1, 6, 18, 15, 24, 184, DateTimeKind.Local).AddTicks(5256) });

            migrationBuilder.UpdateData(
                table: "Tournaments",
                keyColumn: "TournamentId",
                keyValue: 3,
                columns: new[] { "CreatedDate", "EndDate", "LastUpdated", "PrizePool", "RegistrationDeadline", "StartDate" },
                values: new object[] { new DateTime(2025, 12, 30, 18, 15, 24, 184, DateTimeKind.Local).AddTicks(5260), new DateTime(2026, 1, 2, 18, 15, 24, 184, DateTimeKind.Local).AddTicks(5261), new DateTime(2025, 12, 30, 18, 15, 24, 184, DateTimeKind.Local).AddTicks(5260), 2000.00m, new DateTime(2026, 1, 1, 18, 15, 24, 184, DateTimeKind.Local).AddTicks(5263), new DateTime(2026, 1, 2, 18, 15, 24, 184, DateTimeKind.Local).AddTicks(5261) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrizePool",
                table: "Tournaments");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrizePool",
                table: "Tournaments",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "PrizeDistribution",
                columns: table => new
                {
                    PrizeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TournamentId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Place = table.Column<int>(type: "int", nullable: false),
                    PlaceName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PrizeAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrizeDistribution", x => x.PrizeId);
                    table.ForeignKey(
                        name: "FK_PrizeDistribution_Tournaments_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournaments",
                        principalColumn: "TournamentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Tournaments",
                keyColumn: "TournamentId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "EndDate", "LastUpdated", "RegistrationDeadline", "StartDate", "TotalPrizePool" },
                values: new object[] { new DateTime(2025, 12, 30, 17, 56, 13, 41, DateTimeKind.Local).AddTicks(3810), new DateTime(2026, 1, 31, 17, 56, 13, 41, DateTimeKind.Local).AddTicks(3824), new DateTime(2025, 12, 30, 17, 56, 13, 41, DateTimeKind.Local).AddTicks(3818), new DateTime(2026, 1, 24, 17, 56, 13, 41, DateTimeKind.Local).AddTicks(3832), new DateTime(2026, 1, 29, 17, 56, 13, 41, DateTimeKind.Local).AddTicks(3819), 50000.00m });

            migrationBuilder.UpdateData(
                table: "Tournaments",
                keyColumn: "TournamentId",
                keyValue: 2,
                columns: new[] { "CreatedDate", "EndDate", "LastUpdated", "RegistrationDeadline", "StartDate", "TotalPrizePool" },
                values: new object[] { new DateTime(2025, 12, 30, 17, 56, 13, 41, DateTimeKind.Local).AddTicks(3836), new DateTime(2026, 1, 6, 17, 56, 13, 41, DateTimeKind.Local).AddTicks(3837), new DateTime(2025, 12, 30, 17, 56, 13, 41, DateTimeKind.Local).AddTicks(3836), new DateTime(2026, 1, 4, 17, 56, 13, 41, DateTimeKind.Local).AddTicks(3839), new DateTime(2026, 1, 6, 17, 56, 13, 41, DateTimeKind.Local).AddTicks(3837), 1000.00m });

            migrationBuilder.UpdateData(
                table: "Tournaments",
                keyColumn: "TournamentId",
                keyValue: 3,
                columns: new[] { "CreatedDate", "EndDate", "LastUpdated", "RegistrationDeadline", "StartDate", "TotalPrizePool" },
                values: new object[] { new DateTime(2025, 12, 30, 17, 56, 13, 41, DateTimeKind.Local).AddTicks(3841), new DateTime(2026, 1, 2, 17, 56, 13, 41, DateTimeKind.Local).AddTicks(3842), new DateTime(2025, 12, 30, 17, 56, 13, 41, DateTimeKind.Local).AddTicks(3841), new DateTime(2026, 1, 1, 17, 56, 13, 41, DateTimeKind.Local).AddTicks(3844), new DateTime(2026, 1, 2, 17, 56, 13, 41, DateTimeKind.Local).AddTicks(3842), 2000.00m });

            migrationBuilder.CreateIndex(
                name: "IX_PrizeDistribution_TournamentId",
                table: "PrizeDistribution",
                column: "TournamentId");
        }
    }
}
