using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FMS.Migrations
{
    /// <inheritdoc />
    public partial class _0003 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BackedUpTebConfigId",
                table: "Forklifts",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TebConfigData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ForwardMaxVelocity = table.Column<string>(type: "TEXT", nullable: false),
                    BackwardMaxVelocity = table.Column<string>(type: "TEXT", nullable: false),
                    TurningMaxVelocity = table.Column<string>(type: "TEXT", nullable: false),
                    AccelerationLimitX = table.Column<string>(type: "TEXT", nullable: false),
                    TurningAccelerationLimit = table.Column<string>(type: "TEXT", nullable: false),
                    TurningRadius = table.Column<string>(type: "TEXT", nullable: false),
                    WheelBase = table.Column<string>(type: "TEXT", nullable: false),
                    GoalToleranceXY = table.Column<string>(type: "TEXT", nullable: false),
                    GoalToleranceYaw = table.Column<string>(type: "TEXT", nullable: false),
                    MinimalObstacleDistance = table.Column<string>(type: "TEXT", nullable: false),
                    StaticObstacleInflationRadius = table.Column<string>(type: "TEXT", nullable: false),
                    DynamicObstacleInflationRadius = table.Column<string>(type: "TEXT", nullable: false),
                    DtRef = table.Column<string>(type: "TEXT", nullable: false),
                    DtHysteresis = table.Column<string>(type: "TEXT", nullable: false),
                    IncludeDynamicObstacles = table.Column<bool>(type: "INTEGER", nullable: false),
                    IncludeCostmapObstacles = table.Column<bool>(type: "INTEGER", nullable: false),
                    OscillationRecovery = table.Column<bool>(type: "INTEGER", nullable: false),
                    AllowInitializeWithBackwardMotion = table.Column<bool>(type: "INTEGER", nullable: false),
                    SaveSettings = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TebConfigData", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Forklifts_TebConfigData_BackedUpTebConfigId",
                table: "Forklifts");

            migrationBuilder.DropTable(
                name: "TebConfigData");

            migrationBuilder.DropIndex(
                name: "IX_Forklifts_BackedUpTebConfigId",
                table: "Forklifts");

            migrationBuilder.DropColumn(
                name: "BackedUpTebConfigId",
                table: "Forklifts");
        }
    }
}
