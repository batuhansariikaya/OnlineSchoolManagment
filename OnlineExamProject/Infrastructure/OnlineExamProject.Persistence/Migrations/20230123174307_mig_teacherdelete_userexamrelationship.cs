using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineExamProject.Persistence.Migrations
{
    public partial class mig_teacherdelete_userexamrelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Teachers_TeacherId",
                table: "Exams");

            migrationBuilder.DropIndex(
                name: "IX_Exams_TeacherId",
                table: "Exams");

            migrationBuilder.RenameColumn(
                name: "TeacherId",
                table: "Exams",
                newName: "UserId");

            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "Exams",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Exams_AppUserId",
                table: "Exams",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_AspNetUsers_AppUserId",
                table: "Exams",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exams_AspNetUsers_AppUserId",
                table: "Exams");

            migrationBuilder.DropIndex(
                name: "IX_Exams_AppUserId",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Exams");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Exams",
                newName: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_TeacherId",
                table: "Exams",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Teachers_TeacherId",
                table: "Exams",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
