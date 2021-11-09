using Microsoft.EntityFrameworkCore.Migrations;

namespace QuickPropForum.Migrations
{
    public partial class databasechanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_Users",
                table: "Post");

            migrationBuilder.RenameColumn(
                name: "PostContent",
                table: "Post",
                newName: "Description");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Post",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ParentID",
                table: "Post",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Users",
                table: "Post",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
