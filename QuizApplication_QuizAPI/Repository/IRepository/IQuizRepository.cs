using QuizApplication_QuizAPI.Models.DTOs;

namespace QuizApplication_QuizAPI.Repository.IRepository
{
	public interface IQuizRepository
	{
		Task<List<QuestionDTO>> GetQuizQuestionsAsync(int quizId);
		Task<AnswerValidationDTO> ValidateAnswerAsync(AnswerSubmissionDTO submission);
		Task<QuizResultDTO> GetQuizResultAsync(int attemptId);
	}
}
