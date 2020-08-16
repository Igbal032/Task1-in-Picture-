using Microsoft.EntityFrameworkCore.Migrations;

namespace LastOne.Migrations
{
    public partial class initial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "numbers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    phoneNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_numbers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "numberToUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    NumberId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_numberToUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_numberToUsers_numbers_NumberId",
                        column: x => x.NumberId,
                        principalTable: "numbers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_numberToUsers_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_numberToUsers_NumberId",
                table: "numberToUsers",
                column: "NumberId");

            migrationBuilder.CreateIndex(
                name: "IX_numberToUsers_UserId",
                table: "numberToUsers",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "numberToUsers");

            migrationBuilder.DropTable(
                name: "numbers");
        }
    }
}
