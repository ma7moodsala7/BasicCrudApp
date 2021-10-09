using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LegalAdvice.Persistence.Migrations
{
    public partial class MakeLawyerIdNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Lawyers_LawyerId",
                table: "Requests");

            migrationBuilder.AlterColumn<Guid>(
                name: "LawyerId",
                table: "Requests",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Lawyers_LawyerId",
                table: "Requests",
                column: "LawyerId",
                principalTable: "Lawyers",
                principalColumn: "LawyerId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Lawyers_LawyerId",
                table: "Requests");

            migrationBuilder.AlterColumn<Guid>(
                name: "LawyerId",
                table: "Requests",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Lawyers_LawyerId",
                table: "Requests",
                column: "LawyerId",
                principalTable: "Lawyers",
                principalColumn: "LawyerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
