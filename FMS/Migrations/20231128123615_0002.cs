using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FMS.Migrations
{
    /// <inheritdoc />
    public partial class _0002 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "JobTypeId",
                table: "JobSteps",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_JobSteps_JobTypeId",
                table: "JobSteps",
                column: "JobTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobSteps_JobStepTypes_JobTypeId",
                table: "JobSteps",
                column: "JobTypeId",
                principalTable: "JobStepTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobSteps_JobStepTypes_JobTypeId",
                table: "JobSteps");

            migrationBuilder.DropIndex(
                name: "IX_JobSteps_JobTypeId",
                table: "JobSteps");

            migrationBuilder.DropColumn(
                name: "JobTypeId",
                table: "JobSteps");
        }
    }
}
