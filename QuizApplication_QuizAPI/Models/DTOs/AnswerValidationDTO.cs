namespace QuizApplication_QuizAPI.Models.DTOs
{
	public class AnswerSubmissionDTO
	{
		public int AttemptId { get; set; }
		public int QuestionId { get; set; }
		public int SelectedOptionId { get; set; }
	}
	public class AnswerValidationDTO
	{
		public bool IsCorrect { get; set; }
		public string Feedback { get; set; } = string.Empty;
		public string CorrectAnswer { get; set; } = string.Empty;
		
	}

}
