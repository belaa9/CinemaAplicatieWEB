using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaAplicatieWEB.Migrations
{
    /// <inheritdoc />
    public partial class UpdateReservationModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Showtime_ShowtimeId",
                table: "Reservation");

            migrationBuilder.RenameColumn(
                name: "ShowtimeId",
                table: "Reservation",
                newName: "HallId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservation_ShowtimeId",
                table: "Reservation",
                newName: "IX_Reservation_HallId");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReservationDate",
                table: "Reservation",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "Layout",
                table: "Hall",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Hall_HallId",
                table: "Reservation",
                column: "HallId",
                principalTable: "Hall",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Hall_HallId",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "ReservationDate",
                table: "Reservation");

            migrationBuilder.RenameColumn(
                name: "HallId",
                table: "Reservation",
                newName: "ShowtimeId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservation_HallId",
                table: "Reservation",
                newName: "IX_Reservation_ShowtimeId");

            migrationBuilder.AlterColumn<string>(
                name: "Layout",
                table: "Hall",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Showtime_ShowtimeId",
                table: "Reservation",
                column: "ShowtimeId",
                principalTable: "Showtime",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
