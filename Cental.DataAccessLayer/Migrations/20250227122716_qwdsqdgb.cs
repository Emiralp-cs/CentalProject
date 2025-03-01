using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cental.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class qwdsqdgb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookingIdP",
                table: "CheckIsApproveds");

            migrationBuilder.DropColumn(
                name: "CarIdP",
                table: "CheckIsApproveds");

            migrationBuilder.DropColumn(
                name: "IsApprovedP",
                table: "CheckIsApproveds");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookingIdP",
                table: "CheckIsApproveds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CarIdP",
                table: "CheckIsApproveds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsApprovedP",
                table: "CheckIsApproveds",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
