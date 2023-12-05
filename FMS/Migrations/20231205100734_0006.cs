using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FMS.Migrations
{
    /// <inheritdoc />
    public partial class _0006 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Forklifts_TebConfigData_BackedUpTebConfigId",
                table: "Forklifts");

            migrationBuilder.DropIndex(
                name: "IX_Forklifts_BackedUpTebConfigId",
                table: "Forklifts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TebConfigData",
                table: "TebConfigData");

            migrationBuilder.DropColumn(
                name: "BackedUpTebConfigId",
                table: "Forklifts");

            migrationBuilder.RenameTable(
                name: "TebConfigData",
                newName: "tebConfigDatas");

            migrationBuilder.AddColumn<int>(
                name: "ForkliftId",
                table: "tebConfigDatas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_tebConfigDatas",
                table: "tebConfigDatas",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_tebConfigDatas_ForkliftId",
                table: "tebConfigDatas",
                column: "ForkliftId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tebConfigDatas_Forklifts_ForkliftId",
                table: "tebConfigDatas",
                column: "ForkliftId",
                principalTable: "Forklifts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tebConfigDatas_Forklifts_ForkliftId",
                table: "tebConfigDatas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tebConfigDatas",
                table: "tebConfigDatas");

            migrationBuilder.DropIndex(
                name: "IX_tebConfigDatas_ForkliftId",
                table: "tebConfigDatas");

            migrationBuilder.DropColumn(
                name: "ForkliftId",
                table: "tebConfigDatas");

            migrationBuilder.RenameTable(
                name: "tebConfigDatas",
                newName: "TebConfigData");

            migrationBuilder.AddColumn<int>(
                name: "BackedUpTebConfigId",
                table: "Forklifts",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TebConfigData",
                table: "TebConfigData",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Forklifts_BackedUpTebConfigId",
                table: "Forklifts",
                column: "BackedUpTebConfigId");

            migrationBuilder.AddForeignKey(
                name: "FK_Forklifts_TebConfigData_BackedUpTebConfigId",
                table: "Forklifts",
                column: "BackedUpTebConfigId",
                principalTable: "TebConfigData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
