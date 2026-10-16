using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RaceDay.API.Migrations
{
    /// <inheritdoc />
    public partial class AlignWithPart1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Enrollments",
                table: "Enrollments");

            migrationBuilder.DropColumn(
                name: "EventDate",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "EventDescription",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Organiser",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Enrollments",
                newName: "EventEnrollments");

            migrationBuilder.RenameColumn(
                name: "EventId",
                table: "Events",
                newName: "EventID");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Categories",
                newName: "CategoryID");

            migrationBuilder.RenameColumn(
                name: "EventId",
                table: "EventEnrollments",
                newName: "EventID");

            migrationBuilder.RenameColumn(
                name: "EnrollmentId",
                table: "EventEnrollments",
                newName: "EnrollmentID");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "EventEnrollments",
                newName: "ParticipantID");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Events",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "OrganiserID",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EventID",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EnrollmentDate",
                table: "EventEnrollments",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventEnrollments",
                table: "EventEnrollments",
                column: "EnrollmentID");

            migrationBuilder.CreateTable(
                name: "Organisers",
                columns: table => new
                {
                    OrganiserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phonenumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organisers", x => x.OrganiserID);
                });

            migrationBuilder.CreateTable(
                name: "Participants",
                columns: table => new
                {
                    ParticipantID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participants", x => x.ParticipantID);
                });

            migrationBuilder.CreateTable(
                name: "Results",
                columns: table => new
                {
                    ResultsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParticipantID = table.Column<int>(type: "int", nullable: false),
                    EventID = table.Column<int>(type: "int", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    FinishTime = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Results", x => x.ResultsID);
                    table.ForeignKey(
                        name: "FK_Results_Events_EventID",
                        column: x => x.EventID,
                        principalTable: "Events",
                        principalColumn: "EventID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Results_Participants_ParticipantID",
                        column: x => x.ParticipantID,
                        principalTable: "Participants",
                        principalColumn: "ParticipantID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_OrganiserID",
                table: "Events",
                column: "OrganiserID");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_EventID",
                table: "Categories",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_EventEnrollments_EventID",
                table: "EventEnrollments",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_EventEnrollments_ParticipantID",
                table: "EventEnrollments",
                column: "ParticipantID");

            migrationBuilder.CreateIndex(
                name: "IX_Results_EventID",
                table: "Results",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_Results_ParticipantID",
                table: "Results",
                column: "ParticipantID");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Events_EventID",
                table: "Categories",
                column: "EventID",
                principalTable: "Events",
                principalColumn: "EventID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventEnrollments_Events_EventID",
                table: "EventEnrollments",
                column: "EventID",
                principalTable: "Events",
                principalColumn: "EventID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventEnrollments_Participants_ParticipantID",
                table: "EventEnrollments",
                column: "ParticipantID",
                principalTable: "Participants",
                principalColumn: "ParticipantID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Organisers_OrganiserID",
                table: "Events",
                column: "OrganiserID",
                principalTable: "Organisers",
                principalColumn: "OrganiserID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Events_EventID",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_EventEnrollments_Events_EventID",
                table: "EventEnrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_EventEnrollments_Participants_ParticipantID",
                table: "EventEnrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Organisers_OrganiserID",
                table: "Events");

            migrationBuilder.DropTable(
                name: "Organisers");

            migrationBuilder.DropTable(
                name: "Results");

            migrationBuilder.DropTable(
                name: "Participants");

            migrationBuilder.DropIndex(
                name: "IX_Events_OrganiserID",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Categories_EventID",
                table: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventEnrollments",
                table: "EventEnrollments");

            migrationBuilder.DropIndex(
                name: "IX_EventEnrollments_EventID",
                table: "EventEnrollments");

            migrationBuilder.DropIndex(
                name: "IX_EventEnrollments_ParticipantID",
                table: "EventEnrollments");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "OrganiserID",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "EventID",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "EventEnrollments",
                newName: "Enrollments");

            migrationBuilder.RenameColumn(
                name: "EventID",
                table: "Events",
                newName: "EventId");

            migrationBuilder.RenameColumn(
                name: "CategoryID",
                table: "Categories",
                newName: "CategoryId");

            migrationBuilder.RenameColumn(
                name: "EventID",
                table: "Enrollments",
                newName: "EventId");

            migrationBuilder.RenameColumn(
                name: "EnrollmentID",
                table: "Enrollments",
                newName: "EnrollmentId");

            migrationBuilder.RenameColumn(
                name: "ParticipantID",
                table: "Enrollments",
                newName: "UserId");

            migrationBuilder.AddColumn<string>(
                name: "EventDate",
                table: "Events",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EventDescription",
                table: "Events",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Organiser",
                table: "Events",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EnrollmentDate",
                table: "Enrollments",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Enrollments",
                table: "Enrollments",
                column: "EnrollmentId");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });
        }
    }
}
