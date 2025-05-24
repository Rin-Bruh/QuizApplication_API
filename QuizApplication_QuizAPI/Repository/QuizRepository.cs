using Microsoft.EntityFrameworkCore;
using QuizApplication_QuizAPI.Data;
using QuizApplication_QuizAPI.Models;
using QuizApplication_QuizAPI.Models.DTOs;
using QuizApplication_QuizAPI.Repository.IRepository;

namespace QuizApplication_QuizAPI.Repository
{
	public class QuizRepository : IQuizRepository
	{
		private readonly ApplicationDbContext _db;
		public QuizRepository(ApplicationDbContext db)
		{
			_db = db;
		}
		public async Task<List<QuestionDTO>> GetQuizQuestionsAsync(int quizId)
		{
			var questions = await _db.Questions
				.Include(q => q.AnswerOptions)
				.Where(q => q.QuizId == quizId)
				.Select(q => new QuestionDTO
				{
					QuestionId = q.QuestionId,
					QuestionText = q.QuestionText,
					Options = q.AnswerOptions.Select(ao => new AnswerOptionDTO
					{
						OptionId = ao.OptionId,
						OptionText = ao.OptionText
					}).ToList()
				})
				.ToListAsync();

			return questions;
		}

		public async Task<AnswerValidationDTO> ValidateAnswerAsync(AnswerSubmissionDTO submission)
		{
			// Get the selected option with question details
			var selectedOption = await _db.AnswerOptions
				.Include(ao => ao.Question)
				.FirstOrDefaultAsync(ao => ao.OptionId == submission.SelectedOptionId);

			if (selectedOption == null)
			{
				throw new ArgumentException("Invalid option selected");
			}

			// Get the correct answer for this question
			var correctOption = await _db.AnswerOptions
				.FirstOrDefaultAsync(ao => ao.QuestionId == selectedOption.QuestionId && ao.IsCorrect);

			bool isCorrect = selectedOption.IsCorrect;

			// Save the user's answer
			var userAnswer = new UserAnswer
			{
				AttemptId = submission.AttemptId,
				QuestionId = submission.QuestionId,
				SelectedOptionId = submission.SelectedOptionId,
				IsCorrect = isCorrect
			};

			_db.UserAnswers.Add(userAnswer);
			await _db.SaveChangesAsync();

			return new AnswerValidationDTO
			{
				IsCorrect = isCorrect,
				Feedback = isCorrect ? "Correct! Well done." : "Incorrect. Try again next time.",
				CorrectAnswer = correctOption?.OptionText ?? "No correct answer found"
			};
		}

		public async Task<QuizResultDTO> GetQuizResultAsync(int attemptId)
		{
			var attempt = await _db.QuizAttempts
				.Include(qa => qa.Quiz)
				.Include(qa => qa.UserAnswers)
					.ThenInclude(ua => ua.Question)
				.Include(qa => qa.UserAnswers)
					.ThenInclude(ua => ua.SelectedOption)
				.FirstOrDefaultAsync(qa => qa.AttemptId == attemptId);

			if (attempt == null)
			{
				throw new ArgumentException("Quiz attempt not found");
			}

			// Calculate statistics
			var correctAnswers = attempt.UserAnswers.Count(ua => ua.IsCorrect);
			var incorrectAnswers = attempt.UserAnswers.Count(ua => !ua.IsCorrect);
			var totalQuestions = attempt.Quiz.TotalQuestion;

			// Calculate time taken
			var timeTaken = attempt.EndTime.HasValue
				? FormatTimeDuration(attempt.EndTime.Value - attempt.StartTime)
				: "In Progress";

			// Get question results for review
			var questionResults = new List<QuestionResultDTO>();

			foreach (var userAnswer in attempt.UserAnswers)
			{
				var correctOption = await _db.AnswerOptions
					.FirstOrDefaultAsync(ao => ao.QuestionId == userAnswer.QuestionId && ao.IsCorrect);

				questionResults.Add(new QuestionResultDTO
				{
					QuestionId = userAnswer.QuestionId,
					QuestionText = userAnswer.Question.QuestionText,
					SelectedAnswer = userAnswer.SelectedOption.OptionText,
					CorrectAnswer = correctOption?.OptionText ?? "No correct answer",
					IsCorrect = userAnswer.IsCorrect
				});
			}

			return new QuizResultDTO
			{
				AttemptId = attemptId,
				QuizTitle = attempt.Quiz.QuizTitle,
				Passed = attempt.Passed,
				Score = attempt.Score,
				PassingScore = attempt.Quiz.PassingScore,
				CorrectAnswers = correctAnswers,
				IncorrectAnswers = incorrectAnswers,
				TotalQuestions = totalQuestions,
				TimeTaken = timeTaken,
				StartTime = attempt.StartTime,
				EndTime = attempt.EndTime ?? DateTime.Now,
				QuestionResults = questionResults
			};
		}

		private string FormatTimeDuration(TimeSpan duration)
		{
			if (duration.TotalHours >= 1)
			{
				return $"{(int)duration.TotalHours}h {duration.Minutes}m {duration.Seconds}s";
			}
			else if (duration.TotalMinutes >= 1)
			{
				return $"{duration.Minutes}m {duration.Seconds}s";
			}
			else
			{
				return $"{duration.Seconds}s";
			}
		}
		
	}
}
