using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QuizApplication_QuizAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedUserAnswerTableToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "QuizAttempts",
                keyColumn: "AttemptId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 5, 24, 10, 16, 57, 908, DateTimeKind.Local).AddTicks(6304), new DateTime(2025, 5, 24, 10, 25, 27, 907, DateTimeKind.Local).AddTicks(8492), new DateTime(2025, 5, 24, 10, 16, 57, 890, DateTimeKind.Local).AddTicks(4953) });

            migrationBuilder.UpdateData(
                table: "QuizAttempts",
                keyColumn: "AttemptId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "StartTime" },
                values: new object[] { new DateTime(2025, 5, 24, 11, 46, 57, 908, DateTimeKind.Local).AddTicks(6488), new DateTime(2025, 5, 24, 11, 46, 57, 908, DateTimeKind.Local).AddTicks(6485) });

            migrationBuilder.UpdateData(
                table: "QuizAttempts",
                keyColumn: "AttemptId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 5, 24, 11, 16, 57, 908, DateTimeKind.Local).AddTicks(6494), new DateTime(2025, 5, 24, 11, 29, 12, 908, DateTimeKind.Local).AddTicks(6491), new DateTime(2025, 5, 24, 11, 16, 57, 908, DateTimeKind.Local).AddTicks(6490) });

            migrationBuilder.UpdateData(
                table: "QuizAttempts",
                keyColumn: "AttemptId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "StartTime" },
                values: new object[] { new DateTime(2025, 5, 24, 11, 46, 57, 908, DateTimeKind.Local).AddTicks(6497), new DateTime(2025, 5, 24, 11, 46, 57, 908, DateTimeKind.Local).AddTicks(6495) });

            migrationBuilder.InsertData(
                table: "UserAnswers",
                columns: new[] { "UserAnswerId", "AttemptId", "IsCorrect", "QuestionId", "SelectedOptionId" },
                values: new object[,]
                {
                    { 3, 1, true, 1, 1 },
                    { 4, 1, true, 2, 7 },
                    { 5, 1, true, 3, 10 },
                    { 6, 1, true, 4, 13 },
                    { 7, 1, false, 5, 17 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserAnswers",
                keyColumn: "UserAnswerId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "UserAnswers",
                keyColumn: "UserAnswerId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "UserAnswers",
                keyColumn: "UserAnswerId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "UserAnswers",
                keyColumn: "UserAnswerId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "UserAnswers",
                keyColumn: "UserAnswerId",
                keyValue: 7);

            migrationBuilder.UpdateData(
                table: "QuizAttempts",
                keyColumn: "AttemptId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 5, 24, 9, 1, 52, 18, DateTimeKind.Local).AddTicks(4148), new DateTime(2025, 5, 24, 9, 10, 22, 17, DateTimeKind.Local).AddTicks(6976), new DateTime(2025, 5, 24, 9, 1, 52, 15, DateTimeKind.Local).AddTicks(9543) });

            migrationBuilder.UpdateData(
                table: "QuizAttempts",
                keyColumn: "AttemptId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "StartTime" },
                values: new object[] { new DateTime(2025, 5, 24, 10, 31, 52, 18, DateTimeKind.Local).AddTicks(4397), new DateTime(2025, 5, 24, 10, 31, 52, 18, DateTimeKind.Local).AddTicks(4393) });

            migrationBuilder.UpdateData(
                table: "QuizAttempts",
                keyColumn: "AttemptId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 5, 24, 10, 1, 52, 18, DateTimeKind.Local).AddTicks(4403), new DateTime(2025, 5, 24, 10, 14, 7, 18, DateTimeKind.Local).AddTicks(4400), new DateTime(2025, 5, 24, 10, 1, 52, 18, DateTimeKind.Local).AddTicks(4399) });

            migrationBuilder.UpdateData(
                table: "QuizAttempts",
                keyColumn: "AttemptId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "StartTime" },
                values: new object[] { new DateTime(2025, 5, 24, 10, 31, 52, 18, DateTimeKind.Local).AddTicks(4406), new DateTime(2025, 5, 24, 10, 31, 52, 18, DateTimeKind.Local).AddTicks(4404) });
        }
    }
}
