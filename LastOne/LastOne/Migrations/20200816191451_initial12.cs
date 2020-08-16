using Microsoft.EntityFrameworkCore.Migrations;

namespace LastOne.Migrations
{
    public partial class initial12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "numberToUsers");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "numbers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_numbers_UserId",
                table: "numbers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_numbers_users_UserId",
                table: "numbers",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_numbers_users_UserId",
                table: "numbers");

            migrationBuilder.DropIndex(
                name: "IX_numbers_UserId",
                table: "numbers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "numbers");

            migrationBuilder.CreateTable(
                name: "numberToUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
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
    }
}
