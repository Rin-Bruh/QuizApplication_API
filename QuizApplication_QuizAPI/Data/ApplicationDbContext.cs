using Microsoft.EntityFrameworkCore;
using QuizApplication_QuizAPI.Models;

namespace QuizApplication_QuizAPI.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options) { }

		public DbSet<User> Users { get; set; }
		public DbSet<Quiz> Quizzes { get; set; }
		public DbSet<Question> Questions { get; set; }
		public DbSet<AnswerOption> AnswerOptions { get; set; }
		public DbSet<UserAnswer> UserAnswers { get; set; }
		public DbSet<QuizAttempt> QuizAttempts { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<QuizAttempt>(entity =>
			{
				entity.Property(e => e.CreatedAt).HasDefaultValueSql("GETDATE()");
			});
			modelBuilder.Entity<UserAnswer>(entity =>
			{
				// Prevent cascade delete conflicts
				entity.HasOne(d => d.Question)
					.WithMany(p => p.UserAnswers)
					.HasForeignKey(d => d.QuestionId)
					.OnDelete(DeleteBehavior.NoAction);

				entity.HasOne(d => d.SelectedOption)
					.WithMany(p => p.UserAnswers)
					.HasForeignKey(d => d.SelectedOptionId)
					.OnDelete(DeleteBehavior.NoAction);
			});
			modelBuilder.Entity<QuizAttempt>()
			   .HasIndex(qa => new { qa.UserId, qa.QuizId, qa.CreatedAt });

			modelBuilder.Entity<User>().HasData(
				new User { UserId = 1, Username = "quy",  Email = "quytt@gmail.com" },
                new User { UserId = 2, Username = "dat", Email = "datdt@gmail.com" },
                new User { UserId = 3, Username = "sang", Email = "sangtt@gmail.com" });

			modelBuilder.Entity<Quiz>().HasData(
				new Quiz
				{
					QuizId = 1,
					QuizTitle = "Basic Programming Knowledge",
					TotalQuestion = 5,
					TimeLimitMinute = 10,
					PassingScore = 60.00m
				},
				new Quiz
				{
					QuizId = 2,
					QuizTitle = "Advanced C# Concepts",
					TotalQuestion = 4,
					TimeLimitMinute = 15,
					PassingScore = 75.00m
				},
				new Quiz
				{
					QuizId = 3,
					QuizTitle = "Database Fundamentals",
					TotalQuestion = 3,
					TimeLimitMinute = 8,
					PassingScore = 70.00m
				});

			modelBuilder.Entity<Question>().HasData(
				// Basic Programming Quiz Questions
				new Question { QuestionId = 1, QuizId = 1, QuestionText = "What does HTML stand for?" },
				new Question { QuestionId = 2, QuizId = 1, QuestionText = "Which of the following is a programming language?" },
				new Question { QuestionId = 3, QuizId = 1, QuestionText = "What is the result of 5 + 3 * 2?" },
				new Question { QuestionId = 4, QuizId = 1, QuestionText = "Which symbol is used for single-line comments in C#?" },
				new Question { QuestionId = 5, QuizId = 1, QuestionText = "What does CSS stand for?" },

				// Advanced C# Quiz Questions
				new Question { QuestionId = 6, QuizId = 2, QuestionText = "What is the difference between abstract class and interface?" },
				new Question { QuestionId = 7, QuizId = 2, QuestionText = "Which keyword is used to prevent method overriding?" },
				new Question { QuestionId = 8, QuizId = 2, QuestionText = "What is dependency injection?" },
				new Question { QuestionId = 9, QuizId = 2, QuestionText = "Which collection is thread-safe in C#?" },

				// Database Quiz Questions
				new Question { QuestionId = 10, QuizId = 3, QuestionText = "What does CRUD stand for?" },
				new Question { QuestionId = 11, QuizId = 3, QuestionText = "Which SQL command is used to retrieve data?" },
				new Question { QuestionId = 12, QuizId = 3, QuestionText = "What is a foreign key?" });

			modelBuilder.Entity<AnswerOption>().HasData(
				// Question 1: HTML
				new AnswerOption { OptionId = 1, QuestionId = 1, OptionText = "HyperText Markup Language", IsCorrect = true },
				new AnswerOption { OptionId = 2, QuestionId = 1, OptionText = "High Tech Modern Language", IsCorrect = false },
				new AnswerOption { OptionId = 3, QuestionId = 1, OptionText = "Home Tool Markup Language", IsCorrect = false },
				new AnswerOption { OptionId = 4, QuestionId = 1, OptionText = "Hyperlink and Text Markup Language", IsCorrect = false },

				// Question 2: Programming Language
				new AnswerOption { OptionId = 5, QuestionId = 2, OptionText = "HTML", IsCorrect = false },
				new AnswerOption { OptionId = 6, QuestionId = 2, OptionText = "CSS", IsCorrect = false },
				new AnswerOption { OptionId = 7, QuestionId = 2, OptionText = "JavaScript", IsCorrect = true },
				new AnswerOption { OptionId = 8, QuestionId = 2, OptionText = "XML", IsCorrect = false },

				// Question 3: Math
				new AnswerOption { OptionId = 9, QuestionId = 3, OptionText = "16", IsCorrect = false },
				new AnswerOption { OptionId = 10, QuestionId = 3, OptionText = "11", IsCorrect = true },
				new AnswerOption { OptionId = 11, QuestionId = 3, OptionText = "13", IsCorrect = false },
				new AnswerOption { OptionId = 12, QuestionId = 3, OptionText = "10", IsCorrect = false },

				// Question 4: Comments
				new AnswerOption { OptionId = 13, QuestionId = 4, OptionText = "//", IsCorrect = true },
				new AnswerOption { OptionId = 14, QuestionId = 4, OptionText = "/*", IsCorrect = false },
				new AnswerOption { OptionId = 15, QuestionId = 4, OptionText = "#", IsCorrect = false },
				new AnswerOption { OptionId = 16, QuestionId = 4, OptionText = "--", IsCorrect = false },

				// Question 5: CSS
				new AnswerOption { OptionId = 17, QuestionId = 5, OptionText = "Computer Style Sheets", IsCorrect = false },
				new AnswerOption { OptionId = 18, QuestionId = 5, OptionText = "Cascading Style Sheets", IsCorrect = true },
				new AnswerOption { OptionId = 19, QuestionId = 5, OptionText = "Creative Style Sheets", IsCorrect = false },
				new AnswerOption { OptionId = 20, QuestionId = 5, OptionText = "Colorful Style Sheets", IsCorrect = false },

				// Question 6: Abstract vs Interface
				new AnswerOption { OptionId = 21, QuestionId = 6, OptionText = "Abstract class can have implementation, interface cannot", IsCorrect = true },
				new AnswerOption { OptionId = 22, QuestionId = 6, OptionText = "Interface can have implementation, abstract class cannot", IsCorrect = false },
				new AnswerOption { OptionId = 23, QuestionId = 6, OptionText = "They are exactly the same", IsCorrect = false },
				new AnswerOption { OptionId = 24, QuestionId = 6, OptionText = "Abstract class is faster than interface", IsCorrect = false },

				// Question 7: Prevent Override
				new AnswerOption { OptionId = 25, QuestionId = 7, OptionText = "sealed", IsCorrect = true },
				new AnswerOption { OptionId = 26, QuestionId = 7, OptionText = "static", IsCorrect = false },
				new AnswerOption { OptionId = 27, QuestionId = 7, OptionText = "final", IsCorrect = false },
				new AnswerOption { OptionId = 28, QuestionId = 7, OptionText = "override", IsCorrect = false },

				// Question 8: Dependency Injection
				new AnswerOption { OptionId = 29, QuestionId = 8, OptionText = "A design pattern for loose coupling", IsCorrect = true },
				new AnswerOption { OptionId = 30, QuestionId = 8, OptionText = "A way to inject SQL commands", IsCorrect = false },
				new AnswerOption { OptionId = 31, QuestionId = 8, OptionText = "A security vulnerability", IsCorrect = false },
				new AnswerOption { OptionId = 32, QuestionId = 8, OptionText = "A debugging technique", IsCorrect = false },

				// Question 9: Thread-safe Collection
				new AnswerOption { OptionId = 33, QuestionId = 9, OptionText = "List<T>", IsCorrect = false },
				new AnswerOption { OptionId = 34, QuestionId = 9, OptionText = "Dictionary<T,K>", IsCorrect = false },
				new AnswerOption { OptionId = 35, QuestionId = 9, OptionText = "ConcurrentDictionary<T,K>", IsCorrect = true },
				new AnswerOption { OptionId = 36, QuestionId = 9, OptionText = "ArrayList", IsCorrect = false },

				// Question 10: CRUD
				new AnswerOption { OptionId = 37, QuestionId = 10, OptionText = "Create, Read, Update, Delete", IsCorrect = true },
				new AnswerOption { OptionId = 38, QuestionId = 10, OptionText = "Copy, Read, Update, Delete", IsCorrect = false },
				new AnswerOption { OptionId = 39, QuestionId = 10, OptionText = "Create, Retrieve, Update, Delete", IsCorrect = false },
				new AnswerOption { OptionId = 40, QuestionId = 10, OptionText = "Create, Read, Upload, Download", IsCorrect = false },

				// Question 11: SQL Retrieve
				new AnswerOption { OptionId = 41, QuestionId = 11, OptionText = "GET", IsCorrect = false },
				new AnswerOption { OptionId = 42, QuestionId = 11, OptionText = "SELECT", IsCorrect = true },
				new AnswerOption { OptionId = 43, QuestionId = 11, OptionText = "RETRIEVE", IsCorrect = false },
				new AnswerOption { OptionId = 44, QuestionId = 11, OptionText = "FETCH", IsCorrect = false },

				// Question 12: Foreign Key
				new AnswerOption { OptionId = 45, QuestionId = 12, OptionText = "A key from another table that creates relationship", IsCorrect = true },
				new AnswerOption { OptionId = 46, QuestionId = 12, OptionText = "A key from foreign country", IsCorrect = false },
				new AnswerOption { OptionId = 47, QuestionId = 12, OptionText = "A encrypted key for security", IsCorrect = false },
				new AnswerOption { OptionId = 48, QuestionId = 12, OptionText = "A backup key", IsCorrect = false });

			modelBuilder.Entity<QuizAttempt>().HasData(
				// Completed attempt with good score
				new QuizAttempt
				{
					AttemptId = 1,
					UserId = 1,
					QuizId = 1,
					StartTime = DateTime.Now.AddHours(-2),
					EndTime = DateTime.Now.AddHours(-2).AddMinutes(8).AddSeconds(30),
					Score = 80.00m,
					Passed = true,
					CreatedAt = DateTime.Now.AddHours(-2)
				},
				// In-progress attempt
				new QuizAttempt
				{
					AttemptId = 2,
					UserId = 2,
					QuizId = 1,
					StartTime = DateTime.Now.AddMinutes(-30),
					EndTime = null,
					Score = 0.00m,
					Passed = false,
					CreatedAt = DateTime.Now.AddMinutes(-30)
				},
				// Failed attempt
				new QuizAttempt
				{
					AttemptId = 3,
					UserId = 3,
					QuizId = 2,
					StartTime = DateTime.Now.AddHours(-1),
					EndTime = DateTime.Now.AddHours(-1).AddMinutes(12).AddSeconds(15),
					Score = 50.00m,
					Passed = false,
					CreatedAt = DateTime.Now.AddHours(-1)
				},
				new QuizAttempt
				{
					AttemptId = 4,
					UserId = 1,
					QuizId = 2,
					StartTime = DateTime.Now.AddMinutes(-30),
					EndTime = null,
					Score = 0.00m,
					Passed = false,
					CreatedAt = DateTime.Now.AddMinutes(-30)
				});

			modelBuilder.Entity<UserAnswer>().HasData(
				new UserAnswer { UserAnswerId = 3, AttemptId = 1, QuestionId = 1, SelectedOptionId = 1, IsCorrect = true },   // HTML correct
				new UserAnswer { UserAnswerId = 4, AttemptId = 1, QuestionId = 2, SelectedOptionId = 7, IsCorrect = true },   // JavaScript correct
				new UserAnswer { UserAnswerId = 5, AttemptId = 1, QuestionId = 3, SelectedOptionId = 10, IsCorrect = true },  // Math correct
				new UserAnswer { UserAnswerId = 6, AttemptId = 1, QuestionId = 4, SelectedOptionId = 13, IsCorrect = true },  // Comments correct
				new UserAnswer { UserAnswerId = 7, AttemptId = 1, QuestionId = 5, SelectedOptionId = 17, IsCorrect = false }); // CSS wrong
		}
	}
}
