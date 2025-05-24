using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QuizApplication_QuizAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedUserAnswerTableToDbP2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "QuizAttempts",
                keyColumn: "AttemptId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 5, 24, 14, 5, 50, 226, DateTimeKind.Local).AddTicks(730), new DateTime(2025, 5, 24, 14, 14, 20, 226, DateTimeKind.Local).AddTicks(83), new DateTime(2025, 5, 24, 14, 5, 50, 224, DateTimeKind.Local).AddTicks(8529) });

            migrationBuilder.UpdateData(
                table: "QuizAttempts",
                keyColumn: "AttemptId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "StartTime" },
                values: new object[] { new DateTime(2025, 5, 24, 15, 35, 50, 226, DateTimeKind.Local).AddTicks(883), new DateTime(2025, 5, 24, 15, 35, 50, 226, DateTimeKind.Local).AddTicks(881) });

            migrationBuilder.UpdateData(
                table: "QuizAttempts",
                keyColumn: "AttemptId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 5, 24, 15, 5, 50, 226, DateTimeKind.Local).AddTicks(887), new DateTime(2025, 5, 24, 15, 18, 5, 226, DateTimeKind.Local).AddTicks(886), new DateTime(2025, 5, 24, 15, 5, 50, 226, DateTimeKind.Local).AddTicks(885) });

            migrationBuilder.UpdateData(
                table: "QuizAttempts",
                keyColumn: "AttemptId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "StartTime" },
                values: new object[] { new DateTime(2025, 5, 24, 15, 35, 50, 226, DateTimeKind.Local).AddTicks(890), new DateTime(2025, 5, 24, 15, 35, 50, 226, DateTimeKind.Local).AddTicks(889) });

            migrationBuilder.InsertData(
                table: "UserAnswers",
                columns: new[] { "UserAnswerId", "AttemptId", "IsCorrect", "QuestionId", "SelectedOptionId" },
                values: new object[,]
                {
                    { 8, 3, true, 6, 21 },
                    { 9, 3, false, 7, 26 },
                    { 10, 3, true, 8, 29 },
                    { 11, 3, false, 9, 33 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserAnswers",
                keyColumn: "UserAnswerId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "UserAnswers",
                keyColumn: "UserAnswerId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "UserAnswers",
                keyColumn: "UserAnswerId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "UserAnswers",
                keyColumn: "UserAnswerId",
                keyValue: 11);

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
        }
    }
}
