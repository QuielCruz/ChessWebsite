using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Website_for_Chess.Migrations
{
    /// <inheritdoc />
    public partial class addadminloginandregistration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Tournaments",
                keyColumn: "TournamentId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "EndDate", "LastUpdated", "RegistrationDeadline", "StartDate" },
                values: new object[] { new DateTime(2025, 12, 30, 21, 45, 28, 213, DateTimeKind.Local).AddTicks(7791), new DateTime(2026, 1, 31, 21, 45, 28, 213, DateTimeKind.Local).AddTicks(7779), new DateTime(2025, 12, 30, 21, 45, 28, 213, DateTimeKind.Local).AddTicks(7792), new DateTime(2026, 1, 24, 21, 45, 28, 213, DateTimeKind.Local).AddTicks(7787), new DateTime(2026, 1, 29, 21, 45, 28, 213, DateTimeKind.Local).AddTicks(7774) });

            migrationBuilder.UpdateData(
                table: "Tournaments",
                keyColumn: "TournamentId",
                keyValue: 2,
                columns: new[] { "CreatedDate", "EndDate", "LastUpdated", "RegistrationDeadline", "StartDate" },
                values: new object[] { new DateTime(2025, 12, 30, 21, 45, 28, 213, DateTimeKind.Local).AddTicks(7798), new DateTime(2026, 1, 6, 21, 45, 28, 213, DateTimeKind.Local).AddTicks(7795), new DateTime(2025, 12, 30, 21, 45, 28, 213, DateTimeKind.Local).AddTicks(7799), new DateTime(2026, 1, 4, 21, 45, 28, 213, DateTimeKind.Local).AddTicks(7797), new DateTime(2026, 1, 6, 21, 45, 28, 213, DateTimeKind.Local).AddTicks(7794) });

            migrationBuilder.UpdateData(
                table: "Tournaments",
                keyColumn: "TournamentId",
                keyValue: 3,
                columns: new[] { "CreatedDate", "EndDate", "LastUpdated", "RegistrationDeadline", "StartDate" },
                values: new object[] { new DateTime(2025, 12, 30, 21, 45, 28, 213, DateTimeKind.Local).AddTicks(7804), new DateTime(2026, 1, 2, 21, 45, 28, 213, DateTimeKind.Local).AddTicks(7802), new DateTime(2025, 12, 30, 21, 45, 28, 213, DateTimeKind.Local).AddTicks(7805), new DateTime(2026, 1, 1, 21, 45, 28, 213, DateTimeKind.Local).AddTicks(7803), new DateTime(2026, 1, 2, 21, 45, 28, 213, DateTimeKind.Local).AddTicks(7801) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastLogin" },
                values: new object[] { new DateTime(2025, 12, 30, 21, 45, 28, 213, DateTimeKind.Local).AddTicks(7226), new DateTime(2025, 12, 30, 21, 45, 28, 213, DateTimeKind.Local).AddTicks(7240) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Tournaments",
                keyColumn: "TournamentId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "EndDate", "LastUpdated", "RegistrationDeadline", "StartDate" },
                values: new object[] { new DateTime(2025, 12, 30, 21, 35, 35, 776, DateTimeKind.Local).AddTicks(7618), new DateTime(2026, 1, 31, 21, 35, 35, 776, DateTimeKind.Local).AddTicks(7626), new DateTime(2025, 12, 30, 21, 35, 35, 776, DateTimeKind.Local).AddTicks(7619), new DateTime(2026, 1, 24, 21, 35, 35, 776, DateTimeKind.Local).AddTicks(7634), new DateTime(2026, 1, 29, 21, 35, 35, 776, DateTimeKind.Local).AddTicks(7621) });

            migrationBuilder.UpdateData(
                table: "Tournaments",
                keyColumn: "TournamentId",
                keyValue: 2,
                columns: new[] { "CreatedDate", "EndDate", "LastUpdated", "RegistrationDeadline", "StartDate" },
                values: new object[] { new DateTime(2025, 12, 30, 21, 35, 35, 776, DateTimeKind.Local).AddTicks(7639), new DateTime(2026, 1, 6, 21, 35, 35, 776, DateTimeKind.Local).AddTicks(7641), new DateTime(2025, 12, 30, 21, 35, 35, 776, DateTimeKind.Local).AddTicks(7640), new DateTime(2026, 1, 4, 21, 35, 35, 776, DateTimeKind.Local).AddTicks(7644), new DateTime(2026, 1, 6, 21, 35, 35, 776, DateTimeKind.Local).AddTicks(7641) });

            migrationBuilder.UpdateData(
                table: "Tournaments",
                keyColumn: "TournamentId",
                keyValue: 3,
                columns: new[] { "CreatedDate", "EndDate", "LastUpdated", "RegistrationDeadline", "StartDate" },
                values: new object[] { new DateTime(2025, 12, 30, 21, 35, 35, 776, DateTimeKind.Local).AddTicks(7645), new DateTime(2026, 1, 2, 21, 35, 35, 776, DateTimeKind.Local).AddTicks(7647), new DateTime(2025, 12, 30, 21, 35, 35, 776, DateTimeKind.Local).AddTicks(7646), new DateTime(2026, 1, 1, 21, 35, 35, 776, DateTimeKind.Local).AddTicks(7649), new DateTime(2026, 1, 2, 21, 35, 35, 776, DateTimeKind.Local).AddTicks(7646) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastLogin" },
                values: new object[] { new DateTime(2025, 12, 30, 21, 35, 35, 776, DateTimeKind.Local).AddTicks(7444), new DateTime(2025, 12, 30, 21, 35, 35, 776, DateTimeKind.Local).AddTicks(7447) });
        }
    }
}
