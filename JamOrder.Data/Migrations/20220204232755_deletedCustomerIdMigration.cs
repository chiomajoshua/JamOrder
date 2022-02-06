using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JamOrder.Data.Migrations
{
    public partial class DeletedCustomerIdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Customer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomerId",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
