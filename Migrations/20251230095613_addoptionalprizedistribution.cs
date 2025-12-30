using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Website_for_Chess.Migrations
{
    /// <inheritdoc />
    public partial class addoptionalprizedistribution : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PrizePool",
                table: "Tournaments",
                newName: "TotalPrizePool");

            migrationBuilder.AlterColumn<string>(
                name: "Rules",
                table: "Tournaments",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AddColumn<decimal>(
                name: "FifthPlacePrize",
                table: "Tournaments",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "FirstPlacePrize",
                table: "Tournaments",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "FourthPlacePrize",
                table: "Tournaments",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SecondPlacePrize",
                table: "Tournaments",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ThirdPlacePrize",
                table: "Tournaments",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PrizeDistribution",
                columns: table => new
                {
                    PrizeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TournamentId = table.Column<int>(type: "int", nullable: false),
                    Place = table.Column<int>(type: "int", nullable: false),
                    PlaceName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PrizeAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                columns: new[] { "CreatedDate", "EndDate", "FifthPlacePrize", "FirstPlacePrize", "FourthPlacePrize", "LastUpdated", "RegistrationDeadline", "SecondPlacePrize", "StartDate", "ThirdPlacePrize" },
                values: new object[] { new DateTime(2025, 12, 30, 17, 56, 13, 41, DateTimeKind.Local).AddTicks(3810), new DateTime(2026, 1, 31, 17, 56, 13, 41, DateTimeKind.Local).AddTicks(3824), null, null, null, new DateTime(2025, 12, 30, 17, 56, 13, 41, DateTimeKind.Local).AddTicks(3818), new DateTime(2026, 1, 24, 17, 56, 13, 41, DateTimeKind.Local).AddTicks(3832), null, new DateTime(2026, 1, 29, 17, 56, 13, 41, DateTimeKind.Local).AddTicks(3819), null });

            migrationBuilder.UpdateData(
                table: "Tournaments",
                keyColumn: "TournamentId",
                keyValue: 2,
                columns: new[] { "CreatedDate", "EndDate", "FifthPlacePrize", "FirstPlacePrize", "FourthPlacePrize", "LastUpdated", "RegistrationDeadline", "SecondPlacePrize", "StartDate", "ThirdPlacePrize" },
                values: new object[] { new DateTime(2025, 12, 30, 17, 56, 13, 41, DateTimeKind.Local).AddTicks(3836), new DateTime(2026, 1, 6, 17, 56, 13, 41, DateTimeKind.Local).AddTicks(3837), null, null, null, new DateTime(2025, 12, 30, 17, 56, 13, 41, DateTimeKind.Local).AddTicks(3836), new DateTime(2026, 1, 4, 17, 56, 13, 41, DateTimeKind.Local).AddTicks(3839), null, new DateTime(2026, 1, 6, 17, 56, 13, 41, DateTimeKind.Local).AddTicks(3837), null });

            migrationBuilder.UpdateData(
                table: "Tournaments",
                keyColumn: "TournamentId",
                keyValue: 3,
                columns: new[] { "CreatedDate", "EndDate", "FifthPlacePrize", "FirstPlacePrize", "FourthPlacePrize", "LastUpdated", "RegistrationDeadline", "SecondPlacePrize", "StartDate", "ThirdPlacePrize" },
                values: new object[] { new DateTime(2025, 12, 30, 17, 56, 13, 41, DateTimeKind.Local).AddTicks(3841), new DateTime(2026, 1, 2, 17, 56, 13, 41, DateTimeKind.Local).AddTicks(3842), null, null, null, new DateTime(2025, 12, 30, 17, 56, 13, 41, DateTimeKind.Local).AddTicks(3841), new DateTime(2026, 1, 1, 17, 56, 13, 41, DateTimeKind.Local).AddTicks(3844), null, new DateTime(2026, 1, 2, 17, 56, 13, 41, DateTimeKind.Local).AddTicks(3842), null });

            migrationBuilder.CreateIndex(
                name: "IX_PrizeDistribution_TournamentId",
                table: "PrizeDistribution",
                column: "TournamentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PrizeDistribution");

            migrationBuilder.DropColumn(
                name: "FifthPlacePrize",
                table: "Tournaments");

            migrationBuilder.DropColumn(
                name: "FirstPlacePrize",
                table: "Tournaments");

            migrationBuilder.DropColumn(
                name: "FourthPlacePrize",
                table: "Tournaments");

            migrationBuilder.DropColumn(
                name: "SecondPlacePrize",
                table: "Tournaments");

            migrationBuilder.DropColumn(
                name: "ThirdPlacePrize",
                table: "Tournaments");

            migrationBuilder.RenameColumn(
                name: "TotalPrizePool",
                table: "Tournaments",
                newName: "PrizePool");

            migrationBuilder.AlterColumn<string>(
                name: "Rules",
                table: "Tournaments",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(2000)",
                oldMaxLength: 2000);

            migrationBuilder.UpdateData(
                table: "Tournaments",
                keyColumn: "TournamentId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "EndDate", "LastUpdated", "RegistrationDeadline", "StartDate" },
                values: new object[] { new DateTime(2025, 12, 30, 16, 37, 45, 705, DateTimeKind.Local).AddTicks(1599), new DateTime(2026, 1, 31, 16, 37, 45, 705, DateTimeKind.Local).AddTicks(1615), new DateTime(2025, 12, 30, 16, 37, 45, 705, DateTimeKind.Local).AddTicks(1609), new DateTime(2026, 1, 24, 16, 37, 45, 705, DateTimeKind.Local).AddTicks(1619), new DateTime(2026, 1, 29, 16, 37, 45, 705, DateTimeKind.Local).AddTicks(1611) });

            migrationBuilder.UpdateData(
                table: "Tournaments",
                keyColumn: "TournamentId",
                keyValue: 2,
                columns: new[] { "CreatedDate", "EndDate", "LastUpdated", "RegistrationDeadline", "StartDate" },
                values: new object[] { new DateTime(2025, 12, 30, 16, 37, 45, 705, DateTimeKind.Local).AddTicks(1623), new DateTime(2026, 1, 6, 16, 37, 45, 705, DateTimeKind.Local).AddTicks(1625), new DateTime(2025, 12, 30, 16, 37, 45, 705, DateTimeKind.Local).AddTicks(1623), new DateTime(2026, 1, 4, 16, 37, 45, 705, DateTimeKind.Local).AddTicks(1626), new DateTime(2026, 1, 6, 16, 37, 45, 705, DateTimeKind.Local).AddTicks(1624) });

            migrationBuilder.UpdateData(
                table: "Tournaments",
                keyColumn: "TournamentId",
                keyValue: 3,
                columns: new[] { "CreatedDate", "EndDate", "LastUpdated", "RegistrationDeadline", "StartDate" },
                values: new object[] { new DateTime(2025, 12, 30, 16, 37, 45, 705, DateTimeKind.Local).AddTicks(1628), new DateTime(2026, 1, 2, 16, 37, 45, 705, DateTimeKind.Local).AddTicks(1630), new DateTime(2025, 12, 30, 16, 37, 45, 705, DateTimeKind.Local).AddTicks(1628), new DateTime(2026, 1, 1, 16, 37, 45, 705, DateTimeKind.Local).AddTicks(1632), new DateTime(2026, 1, 2, 16, 37, 45, 705, DateTimeKind.Local).AddTicks(1629) });
        }
    }
}
