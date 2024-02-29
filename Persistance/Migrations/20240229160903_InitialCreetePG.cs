using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LearnASkill.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreetePG : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    UserEmail = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Goals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    SkillId = table.Column<int>(type: "integer", nullable: false),
                    Dificulty = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Goals_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersGoals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    GoalId = table.Column<int>(type: "integer", nullable: false),
                    InitialDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    FinalDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Completed = table.Column<bool>(type: "boolean", nullable: false),
                    Deadline = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersGoals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersGoals_Goals_GoalId",
                        column: x => x.GoalId,
                        principalTable: "Goals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersGoals_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Learn a new language", "Learn English" },
                    { 2, "Learn to code on C# language", "Programming" },
                    { 3, "Master the art of playing the guitar", "Play the Guitar" },
                    { 4, "Explore the world of data science", "Data Science" },
                    { 5, "Achieve peak fitness levels", "Fitness Training" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "City", "LastName", "Name", "Password", "UserEmail", "UserName" },
                values: new object[] { 1, "Springfield", "Simpson", "Homer", "m4dppKdClZotApjDb7cGI/LfrNqENiN98I2N/Vs3N0w=", "homer_simpson@email.com", "mrX" });

            migrationBuilder.InsertData(
                table: "Goals",
                columns: new[] { "Id", "Dificulty", "Name", "SkillId" },
                values: new object[,]
                {
                    { 1, 1, "Begginer's vocabulary", 1 },
                    { 2, 2, "Conversation Proficiency", 1 },
                    { 3, 3, "Advance skills", 1 },
                    { 4, 1, "C# 101. Basics", 2 },
                    { 5, 2, "OOP. Write a console APP", 2 },
                    { 6, 3, "API. Code a web service", 2 },
                    { 7, 1, "Chords Mastery", 3 },
                    { 8, 2, "Play a Song", 3 },
                    { 9, 3, "Advanced Techniques", 3 },
                    { 10, 1, "Intermediate Data Analysis", 4 },
                    { 11, 2, "Machine Learning Basics", 4 },
                    { 12, 3, "Build a Predictive Model", 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Goals_SkillId",
                table: "Goals",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersGoals_GoalId",
                table: "UsersGoals",
                column: "GoalId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersGoals_UserId",
                table: "UsersGoals",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersGoals");

            migrationBuilder.DropTable(
                name: "Goals");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Skills");
        }
    }
}
