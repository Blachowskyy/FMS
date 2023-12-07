using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FMS.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Forklifts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Port = table.Column<int>(type: "INTEGER", nullable: false),
                    ForkliftAddress = table.Column<string>(type: "TEXT", nullable: false),
                    LidarLocAddress = table.Column<string>(type: "TEXT", nullable: true),
                    VisionaryAddress = table.Column<string>(type: "TEXT", nullable: true),
                    RegistrationDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forklifts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PriorityLevel = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    IsQueued = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsRunning = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDone = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsCanceled = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobStepTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobStepTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LocationType = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    PositionX = table.Column<string>(type: "TEXT", nullable: false),
                    PositionY = table.Column<string>(type: "TEXT", nullable: false),
                    PositionR = table.Column<string>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    NfcTag = table.Column<string>(type: "TEXT", nullable: true),
                    IsClient = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsInstallator = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsAdmin = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsSuperAdmin = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsLogged = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TebConfigDatas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ForkliftId = table.Column<int>(type: "INTEGER", nullable: false),
                    ForwardMaxVelocity = table.Column<string>(type: "TEXT", nullable: true),
                    BackwardMaxVelocity = table.Column<string>(type: "TEXT", nullable: true),
                    TurningMaxVelocity = table.Column<string>(type: "TEXT", nullable: true),
                    AccelerationLinearLimit = table.Column<string>(type: "TEXT", nullable: true),
                    AccelerationAngularLimit = table.Column<string>(type: "TEXT", nullable: true),
                    TurningRadius = table.Column<string>(type: "TEXT", nullable: true),
                    Wheelbase = table.Column<string>(type: "TEXT", nullable: true),
                    GoalToleranceXY = table.Column<string>(type: "TEXT", nullable: true),
                    GoalToleranceYaw = table.Column<string>(type: "TEXT", nullable: true),
                    MinimalObstacleDistance = table.Column<string>(type: "TEXT", nullable: true),
                    StaticObstacleInflationRadius = table.Column<string>(type: "TEXT", nullable: true),
                    DynamicObstacleInflationRadius = table.Column<string>(type: "TEXT", nullable: true),
                    DtRef = table.Column<string>(type: "TEXT", nullable: true),
                    DtHysteresis = table.Column<string>(type: "TEXT", nullable: true),
                    IncludeDynamicObstacles = table.Column<bool>(type: "INTEGER", nullable: false),
                    IncludeCostmapObstacles = table.Column<bool>(type: "INTEGER", nullable: false),
                    OscillationRecovery = table.Column<bool>(type: "INTEGER", nullable: false),
                    AllowInitializeWithBackwardMotion = table.Column<bool>(type: "INTEGER", nullable: false),
                    SaveSettings = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TebConfigDatas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TebConfigDatas_Forklifts_ForkliftId",
                        column: x => x.ForkliftId,
                        principalTable: "Forklifts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobSteps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    JobStepLocationId = table.Column<int>(type: "INTEGER", nullable: false),
                    JobTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    IsRunning = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDone = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsCanceled = table.Column<bool>(type: "INTEGER", nullable: false),
                    JobId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobSteps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobSteps_JobStepTypes_JobTypeId",
                        column: x => x.JobTypeId,
                        principalTable: "JobStepTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobSteps_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_JobSteps_Locations_JobStepLocationId",
                        column: x => x.JobStepLocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobSteps_JobId",
                table: "JobSteps",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_JobSteps_JobStepLocationId",
                table: "JobSteps",
                column: "JobStepLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_JobSteps_JobTypeId",
                table: "JobSteps",
                column: "JobTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TebConfigDatas_ForkliftId",
                table: "TebConfigDatas",
                column: "ForkliftId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobSteps");

            migrationBuilder.DropTable(
                name: "TebConfigDatas");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "JobStepTypes");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Forklifts");
        }
    }
}
