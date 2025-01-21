using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyEfCore.Migrations
{
    public partial class AddAnnotation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentSubject_Subjects_SubjectsId",
                table: "StudentSubject");

            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Teachers_TeacherID",
                table: "Subjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subjects",
                table: "Subjects");

            migrationBuilder.RenameColumn(
                name: "TeacherID",
                table: "Subjects",
                newName: "TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_Subjects_TeacherID",
                table: "Subjects",
                newName: "IX_Subjects_TeacherId");

            migrationBuilder.RenameColumn(
                name: "SubjectsId",
                table: "StudentSubject",
                newName: "SubjectsTeacherID");

            migrationBuilder.RenameIndex(
                name: "IX_StudentSubject_SubjectsId",
                table: "StudentSubject",
                newName: "IX_StudentSubject_SubjectsTeacherID");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Subjects",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "TeacherID",
                table: "Subjects",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subjects",
                table: "Subjects",
                column: "TeacherID");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentSubject_Subjects_SubjectsTeacherID",
                table: "StudentSubject",
                column: "SubjectsTeacherID",
                principalTable: "Subjects",
                principalColumn: "TeacherID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Teachers_TeacherId",
                table: "Subjects",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentSubject_Subjects_SubjectsTeacherID",
                table: "StudentSubject");

            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Teachers_TeacherId",
                table: "Subjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subjects",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "TeacherID",
                table: "Subjects");

            migrationBuilder.RenameColumn(
                name: "TeacherId",
                table: "Subjects",
                newName: "TeacherID");

            migrationBuilder.RenameIndex(
                name: "IX_Subjects_TeacherId",
                table: "Subjects",
                newName: "IX_Subjects_TeacherID");

            migrationBuilder.RenameColumn(
                name: "SubjectsTeacherID",
                table: "StudentSubject",
                newName: "SubjectsId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentSubject_SubjectsTeacherID",
                table: "StudentSubject",
                newName: "IX_StudentSubject_SubjectsId");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Subjects",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subjects",
                table: "Subjects",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentSubject_Subjects_SubjectsId",
                table: "StudentSubject",
                column: "SubjectsId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Teachers_TeacherID",
                table: "Subjects",
                column: "TeacherID",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
