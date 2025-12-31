using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Website_for_Chess.Migrations
{
    /// <inheritdoc />
    public partial class addadminloginandregistration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "Tournaments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TournamentRegistrations",
                columns: table => new
                {
                    TournamentRegistrationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TournamentId = table.Column<int>(type: "int", nullable: false),
                    PlayerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TournamentRegistrations", x => x.TournamentRegistrationId);
                    table.ForeignKey(
                        name: "FK_TournamentRegistrations_Tournaments_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournaments",
                        principalColumn: "TournamentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastLogin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.UpdateData(
                table: "Tournaments",
                keyColumn: "TournamentId",
                keyValue: 1,
                columns: new[] { "CreatedByUserId", "CreatedDate", "EndDate", "LastUpdated", "RegistrationDeadline", "StartDate" },
                values: new object[] { 1, new DateTime(2025, 12, 30, 21, 35, 35, 776, DateTimeKind.Local).AddTicks(7618), new DateTime(2026, 1, 31, 21, 35, 35, 776, DateTimeKind.Local).AddTicks(7626), new DateTime(2025, 12, 30, 21, 35, 35, 776, DateTimeKind.Local).AddTicks(7619), new DateTime(2026, 1, 24, 21, 35, 35, 776, DateTimeKind.Local).AddTicks(7634), new DateTime(2026, 1, 29, 21, 35, 35, 776, DateTimeKind.Local).AddTicks(7621) });

            migrationBuilder.UpdateData(
                table: "Tournaments",
                keyColumn: "TournamentId",
                keyValue: 2,
                columns: new[] { "CreatedByUserId", "CreatedDate", "EndDate", "LastUpdated", "RegistrationDeadline", "StartDate" },
                values: new object[] { 1, new DateTime(2025, 12, 30, 21, 35, 35, 776, DateTimeKind.Local).AddTicks(7639), new DateTime(2026, 1, 6, 21, 35, 35, 776, DateTimeKind.Local).AddTicks(7641), new DateTime(2025, 12, 30, 21, 35, 35, 776, DateTimeKind.Local).AddTicks(7640), new DateTime(2026, 1, 4, 21, 35, 35, 776, DateTimeKind.Local).AddTicks(7644), new DateTime(2026, 1, 6, 21, 35, 35, 776, DateTimeKind.Local).AddTicks(7641) });

            migrationBuilder.UpdateData(
                table: "Tournaments",
                keyColumn: "TournamentId",
                keyValue: 3,
                columns: new[] { "CreatedByUserId", "CreatedDate", "EndDate", "LastUpdated", "RegistrationDeadline", "StartDate" },
                values: new object[] { 1, new DateTime(2025, 12, 30, 21, 35, 35, 776, DateTimeKind.Local).AddTicks(7645), new DateTime(2026, 1, 2, 21, 35, 35, 776, DateTimeKind.Local).AddTicks(7647), new DateTime(2025, 12, 30, 21, 35, 35, 776, DateTimeKind.Local).AddTicks(7646), new DateTime(2026, 1, 1, 21, 35, 35, 776, DateTimeKind.Local).AddTicks(7649), new DateTime(2026, 1, 2, 21, 35, 35, 776, DateTimeKind.Local).AddTicks(7646) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "CreatedAt", "Email", "IsActive", "IsAdmin", "LastLogin", "PasswordHash", "Username" },
                values: new object[] { 1, new DateTime(2025, 12, 30, 21, 35, 35, 776, DateTimeKind.Local).AddTicks(7444), "admin@chessmasters.com", true, true, new DateTime(2025, 12, 30, 21, 35, 35, 776, DateTimeKind.Local).AddTicks(7447), "6G94qKPK8LYNjnTllCqm2G3BUM08AzOK7yW30tfjrMc=", "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Tournaments_CreatedByUserId",
                table: "Tournaments",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TournamentRegistrations_TournamentId",
                table: "TournamentRegistrations",
                column: "TournamentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tournaments_Users_CreatedByUserId",
                table: "Tournaments",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tournaments_Users_CreatedByUserId",
                table: "Tournaments");

            migrationBuilder.DropTable(
                name: "TournamentRegistrations");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Tournaments_CreatedByUserId",
                table: "Tournaments");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Tournaments");

            migrationBuilder.UpdateData(
                table: "Tournaments",
                keyColumn: "TournamentId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "EndDate", "LastUpdated", "RegistrationDeadline", "StartDate" },
                values: new object[] { new DateTime(2025, 12, 30, 18, 15, 24, 184, DateTimeKind.Local).AddTicks(5227), new DateTime(2026, 1, 31, 18, 15, 24, 184, DateTimeKind.Local).AddTicks(5243), new DateTime(2025, 12, 30, 18, 15, 24, 184, DateTimeKind.Local).AddTicks(5236), new DateTime(2026, 1, 24, 18, 15, 24, 184, DateTimeKind.Local).AddTicks(5249), new DateTime(2026, 1, 29, 18, 15, 24, 184, DateTimeKind.Local).AddTicks(5238) });

            migrationBuilder.UpdateData(
                table: "Tournaments",
                keyColumn: "TournamentId",
                keyValue: 2,
                columns: new[] { "CreatedDate", "EndDate", "LastUpdated", "RegistrationDeadline", "StartDate" },
                values: new object[] { new DateTime(2025, 12, 30, 18, 15, 24, 184, DateTimeKind.Local).AddTicks(5254), new DateTime(2026, 1, 6, 18, 15, 24, 184, DateTimeKind.Local).AddTicks(5256), new DateTime(2025, 12, 30, 18, 15, 24, 184, DateTimeKind.Local).AddTicks(5255), new DateTime(2026, 1, 4, 18, 15, 24, 184, DateTimeKind.Local).AddTicks(5258), new DateTime(2026, 1, 6, 18, 15, 24, 184, DateTimeKind.Local).AddTicks(5256) });

            migrationBuilder.UpdateData(
                table: "Tournaments",
                keyColumn: "TournamentId",
                keyValue: 3,
                columns: new[] { "CreatedDate", "EndDate", "LastUpdated", "RegistrationDeadline", "StartDate" },
                values: new object[] { new DateTime(2025, 12, 30, 18, 15, 24, 184, DateTimeKind.Local).AddTicks(5260), new DateTime(2026, 1, 2, 18, 15, 24, 184, DateTimeKind.Local).AddTicks(5261), new DateTime(2025, 12, 30, 18, 15, 24, 184, DateTimeKind.Local).AddTicks(5260), new DateTime(2026, 1, 1, 18, 15, 24, 184, DateTimeKind.Local).AddTicks(5263), new DateTime(2026, 1, 2, 18, 15, 24, 184, DateTimeKind.Local).AddTicks(5261) });
        }
    }
}
