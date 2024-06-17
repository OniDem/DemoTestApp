using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoTestApi.Migrations
{
    /// <inheritdoc />
    public partial class RenameUserEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShiftID",
                table: "users",
                newName: "ShiftIDs");

            migrationBuilder.RenameIndex(
                name: "IX_users_ShiftID",
                table: "users",
                newName: "IX_users_ShiftIDs");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShiftIDs",
                table: "users",
                newName: "ShiftID");

            migrationBuilder.RenameIndex(
                name: "IX_users_ShiftIDs",
                table: "users",
                newName: "IX_users_ShiftID");
        }
    }
}
