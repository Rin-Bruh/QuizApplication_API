using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QuizApplication_QuizAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddAndSeedTableToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Quizzes",
                columns: table => new
                {
                    QuizId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuizTitle = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    TotalQuestion = table.Column<int>(type: "int", nullable: false),
                    TimeLimitMinute = table.Column<int>(type: "int", nullable: false),
                    PassingScore = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quizzes", x => x.QuizId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuizId = table.Column<int>(type: "int", nullable: false),
                    QuestionText = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.QuestionId);
                    table.ForeignKey(
                        name: "FK_Questions_Quizzes_QuizId",
                        column: x => x.QuizId,
                        principalTable: "Quizzes",
                        principalColumn: "QuizId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuizAttempts",
                columns: table => new
                {
                    AttemptId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    QuizId = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Score = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Passed = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizAttempts", x => x.AttemptId);
                    table.ForeignKey(
                        name: "FK_QuizAttempts_Quizzes_QuizId",
                        column: x => x.QuizId,
                        principalTable: "Quizzes",
                        principalColumn: "QuizId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuizAttempts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnswerOptions",
                columns: table => new
                {
                    OptionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    OptionText = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    IsCorrect = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerOptions", x => x.OptionId);
                    table.ForeignKey(
                        name: "FK_AnswerOptions_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAnswers",
                columns: table => new
                {
                    UserAnswerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttemptId = table.Column<int>(type: "int", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    SelectedOptionId = table.Column<int>(type: "int", nullable: false),
                    IsCorrect = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAnswers", x => x.UserAnswerId);
                    table.ForeignKey(
                        name: "FK_UserAnswers_AnswerOptions_SelectedOptionId",
                        column: x => x.SelectedOptionId,
                        principalTable: "AnswerOptions",
                        principalColumn: "OptionId");
                    table.ForeignKey(
                        name: "FK_UserAnswers_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "QuestionId");
                    table.ForeignKey(
                        name: "FK_UserAnswers_QuizAttempts_AttemptId",
                        column: x => x.AttemptId,
                        principalTable: "QuizAttempts",
                        principalColumn: "AttemptId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Quizzes",
                columns: new[] { "QuizId", "PassingScore", "QuizTitle", "TimeLimitMinute", "TotalQuestion" },
                values: new object[,]
                {
                    { 1, 60.00m, "Basic Programming Knowledge", 10, 5 },
                    { 2, 75.00m, "Advanced C# Concepts", 15, 4 },
                    { 3, 70.00m, "Database Fundamentals", 8, 3 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "Username" },
                values: new object[,]
                {
                    { 1, "quytt@gmail.com", "quy" },
                    { 2, "datdt@gmail.com", "dat" },
                    { 3, "sangtt@gmail.com", "sang" }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "QuestionId", "QuestionText", "QuizId" },
                values: new object[,]
                {
                    { 1, "What does HTML stand for?", 1 },
                    { 2, "Which of the following is a programming language?", 1 },
                    { 3, "What is the result of 5 + 3 * 2?", 1 },
                    { 4, "Which symbol is used for single-line comments in C#?", 1 },
                    { 5, "What does CSS stand for?", 1 },
                    { 6, "What is the difference between abstract class and interface?", 2 },
                    { 7, "Which keyword is used to prevent method overriding?", 2 },
                    { 8, "What is dependency injection?", 2 },
                    { 9, "Which collection is thread-safe in C#?", 2 },
                    { 10, "What does CRUD stand for?", 3 },
                    { 11, "Which SQL command is used to retrieve data?", 3 },
                    { 12, "What is a foreign key?", 3 }
                });

            migrationBuilder.InsertData(
                table: "QuizAttempts",
                columns: new[] { "AttemptId", "CreatedAt", "EndTime", "Passed", "QuizId", "Score", "StartTime", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 5, 24, 9, 1, 52, 18, DateTimeKind.Local).AddTicks(4148), new DateTime(2025, 5, 24, 9, 10, 22, 17, DateTimeKind.Local).AddTicks(6976), true, 1, 80.00m, new DateTime(2025, 5, 24, 9, 1, 52, 15, DateTimeKind.Local).AddTicks(9543), 1 },
                    { 2, new DateTime(2025, 5, 24, 10, 31, 52, 18, DateTimeKind.Local).AddTicks(4397), null, false, 1, 0.00m, new DateTime(2025, 5, 24, 10, 31, 52, 18, DateTimeKind.Local).AddTicks(4393), 2 },
                    { 3, new DateTime(2025, 5, 24, 10, 1, 52, 18, DateTimeKind.Local).AddTicks(4403), new DateTime(2025, 5, 24, 10, 14, 7, 18, DateTimeKind.Local).AddTicks(4400), false, 2, 50.00m, new DateTime(2025, 5, 24, 10, 1, 52, 18, DateTimeKind.Local).AddTicks(4399), 3 },
                    { 4, new DateTime(2025, 5, 24, 10, 31, 52, 18, DateTimeKind.Local).AddTicks(4406), null, false, 2, 0.00m, new DateTime(2025, 5, 24, 10, 31, 52, 18, DateTimeKind.Local).AddTicks(4404), 1 }
                });

            migrationBuilder.InsertData(
                table: "AnswerOptions",
                columns: new[] { "OptionId", "IsCorrect", "OptionText", "QuestionId" },
                values: new object[,]
                {
                    { 1, true, "HyperText Markup Language", 1 },
                    { 2, false, "High Tech Modern Language", 1 },
                    { 3, false, "Home Tool Markup Language", 1 },
                    { 4, false, "Hyperlink and Text Markup Language", 1 },
                    { 5, false, "HTML", 2 },
                    { 6, false, "CSS", 2 },
                    { 7, true, "JavaScript", 2 },
                    { 8, false, "XML", 2 },
                    { 9, false, "16", 3 },
                    { 10, true, "11", 3 },
                    { 11, false, "13", 3 },
                    { 12, false, "10", 3 },
                    { 13, true, "//", 4 },
                    { 14, false, "/*", 4 },
                    { 15, false, "#", 4 },
                    { 16, false, "--", 4 },
                    { 17, false, "Computer Style Sheets", 5 },
                    { 18, true, "Cascading Style Sheets", 5 },
                    { 19, false, "Creative Style Sheets", 5 },
                    { 20, false, "Colorful Style Sheets", 5 },
                    { 21, true, "Abstract class can have implementation, interface cannot", 6 },
                    { 22, false, "Interface can have implementation, abstract class cannot", 6 },
                    { 23, false, "They are exactly the same", 6 },
                    { 24, false, "Abstract class is faster than interface", 6 },
                    { 25, true, "sealed", 7 },
                    { 26, false, "static", 7 },
                    { 27, false, "final", 7 },
                    { 28, false, "override", 7 },
                    { 29, true, "A design pattern for loose coupling", 8 },
                    { 30, false, "A way to inject SQL commands", 8 },
                    { 31, false, "A security vulnerability", 8 },
                    { 32, false, "A debugging technique", 8 },
                    { 33, false, "List<T>", 9 },
                    { 34, false, "Dictionary<T,K>", 9 },
                    { 35, true, "ConcurrentDictionary<T,K>", 9 },
                    { 36, false, "ArrayList", 9 },
                    { 37, true, "Create, Read, Update, Delete", 10 },
                    { 38, false, "Copy, Read, Update, Delete", 10 },
                    { 39, false, "Create, Retrieve, Update, Delete", 10 },
                    { 40, false, "Create, Read, Upload, Download", 10 },
                    { 41, false, "GET", 11 },
                    { 42, true, "SELECT", 11 },
                    { 43, false, "RETRIEVE", 11 },
                    { 44, false, "FETCH", 11 },
                    { 45, true, "A key from another table that creates relationship", 12 },
                    { 46, false, "A key from foreign country", 12 },
                    { 47, false, "A encrypted key for security", 12 },
                    { 48, false, "A backup key", 12 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnswerOptions_QuestionId",
                table: "AnswerOptions",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_QuizId",
                table: "Questions",
                column: "QuizId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizAttempts_QuizId",
                table: "QuizAttempts",
                column: "QuizId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizAttempts_UserId_QuizId_CreatedAt",
                table: "QuizAttempts",
                columns: new[] { "UserId", "QuizId", "CreatedAt" });

            migrationBuilder.CreateIndex(
                name: "IX_UserAnswers_AttemptId",
                table: "UserAnswers",
                column: "AttemptId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAnswers_QuestionId",
                table: "UserAnswers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAnswers_SelectedOptionId",
                table: "UserAnswers",
                column: "SelectedOptionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserAnswers");

            migrationBuilder.DropTable(
                name: "AnswerOptions");

            migrationBuilder.DropTable(
                name: "QuizAttempts");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Quizzes");
        }
    }
}
