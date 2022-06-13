using Microsoft.EntityFrameworkCore.Migrations;

namespace Eduhomee.Migrations
{
    public partial class BioDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "bios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(nullable: true),
                    Logo = table.Column<string>(nullable: true),
                    Facebook = table.Column<string>(nullable: true),
                    Vcontact = table.Column<string>(nullable: true),
                    Twitter = table.Column<string>(nullable: true),
                    Pinterest = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bios", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bios");
        }
    }
}
