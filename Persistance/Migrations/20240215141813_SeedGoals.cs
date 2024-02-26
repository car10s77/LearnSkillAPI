using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LearnASkill.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class SeedGoals : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Goals",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Goals",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Goals",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Goals",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Goals",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Goals",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Goals",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Goals",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Goals",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Goals",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Goals",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Goals",
                keyColumn: "Id",
                keyValue: 12);
        }
    }
}
