using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScheduleManager.Web.Migrations
{
    public partial class jobid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "JobId",
                table: "ScheduleEvents",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JobId",
                table: "ScheduleEvents");
        }
    }
}
