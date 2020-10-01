using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogSite.Web.Migrations.Database
{
    public partial class commentUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "MainComments",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "MainComments");
        }
    }
}
