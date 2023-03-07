using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineExamProject.Persistence.Migrations
{
    public partial class mig_yenilenmis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Exams_ExamId",
                table: "Grades");

            migrationBuilder.DropIndex(
                name: "IX_Grades_ExamId",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "ExamId",
                table: "Grades");

            migrationBuilder.AddColumn<int>(
                name: "GradeId",
                table: "Exams",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Exams_GradeId",
                table: "Exams",
                column: "GradeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Grades_GradeId",
                table: "Exams",
                column: "GradeId",
                principalTable: "Grades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Grades_GradeId",
                table: "Exams");

            migrationBuilder.DropIndex(
                name: "IX_Exams_GradeId",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "GradeId",
                table: "Exams");

            migrationBuilder.AddColumn<int>(
                name: "ExamId",
                table: "Grades",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Grades_ExamId",
                table: "Grades",
                column: "ExamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Exams_ExamId",
                table: "Grades",
                column: "ExamId",
                principalTable: "Exams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
