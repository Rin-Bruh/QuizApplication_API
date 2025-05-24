namespace QuizApplication_QuizAPI.Models.DTOs
{
	public class QuizResultDTO
	{
		public int AttemptId { get; set; }
		public string QuizTitle { get; set; } = string.Empty;
		public bool Passed { get; set; }
		public decimal Score { get; set; }
		public decimal PassingScore { get; set; }
		public int CorrectAnswers { get; set; }
		public int IncorrectAnswers { get; set; }
		public int TotalQuestions { get; set; }
		public string TimeTaken { get; set; } = string.Empty;
		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }
		public List<QuestionResultDTO> QuestionResults { get; set; } = new List<QuestionResultDTO>();
	}
	public class QuestionResultDTO
	{
		public int QuestionId { get; set; }
		public string QuestionText { get; set; } = string.Empty;
		public string SelectedAnswer { get; set; } = string.Empty;
		public string CorrectAnswer { get; set; } = string.Empty;
		public bool IsCorrect { get; set; }
	}
}
