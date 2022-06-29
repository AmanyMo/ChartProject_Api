using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChartProject_Api.Migrations
{
    public partial class O : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Technical_Data_Orange",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    Service = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    ContractDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ContractExpiryDate = table.Column<string>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Technical_Data_Orange", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Technical_Data_Orange");
        }
    }
}
