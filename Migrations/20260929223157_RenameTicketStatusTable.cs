using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserRoles.Migrations
{
    /// <inheritdoc />
    public partial class RenameTicketStatusTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketStatus",
                table: "TicketStatus");

            migrationBuilder.RenameTable(
                name: "TicketStatus",
                newName: "TablaTicketStatus");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TablaTicketStatus",
                table: "TablaTicketStatus",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TablaTicketStatus",
                table: "TablaTicketStatus");

            migrationBuilder.RenameTable(
                name: "TablaTicketStatus",
                newName: "TicketStatus");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketStatus",
                table: "TicketStatus",
                column: "Id");
        }
    }
}
