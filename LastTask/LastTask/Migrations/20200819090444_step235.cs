using Microsoft.EntityFrameworkCore.Migrations;

namespace LastTask.Migrations
{
    public partial class step235 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_numbers_NumberId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "numbers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_NumberId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NumberId",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "numbers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    phoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_numbers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_NumberId",
                table: "AspNetUsers",
                column: "NumberId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_numbers_NumberId",
                table: "AspNetUsers",
                column: "NumberId",
                principalTable: "numbers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
