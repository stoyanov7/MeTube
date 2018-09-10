using Microsoft.EntityFrameworkCore.Migrations;

namespace MeTube.Data.Migrations
{
    public partial class UploaderIdString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tubes_AspNetUsers_UploaderId1",
                table: "Tubes");

            migrationBuilder.DropIndex(
                name: "IX_Tubes_UploaderId1",
                table: "Tubes");

            migrationBuilder.DropColumn(
                name: "UploaderId1",
                table: "Tubes");

            migrationBuilder.AlterColumn<string>(
                name: "UploaderId",
                table: "Tubes",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Tubes_UploaderId",
                table: "Tubes",
                column: "UploaderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tubes_AspNetUsers_UploaderId",
                table: "Tubes",
                column: "UploaderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tubes_AspNetUsers_UploaderId",
                table: "Tubes");

            migrationBuilder.DropIndex(
                name: "IX_Tubes_UploaderId",
                table: "Tubes");

            migrationBuilder.AlterColumn<int>(
                name: "UploaderId",
                table: "Tubes",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "UploaderId1",
                table: "Tubes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tubes_UploaderId1",
                table: "Tubes",
                column: "UploaderId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Tubes_AspNetUsers_UploaderId1",
                table: "Tubes",
                column: "UploaderId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
