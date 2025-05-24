namespace QuizApplication_QuizAPI.Models.DTOs
{
	public class QuestionDTO
	{
		public int QuestionId { get; set; }
		public string QuestionText { get; set; } = string.Empty;
		public List<AnswerOptionDTO> Options { get; set; } = new List<AnswerOptionDTO>();
	}
	public class AnswerOptionDTO
	{
		public int OptionId { get; set; }
		public string OptionText { get; set; } = string.Empty;
	}
}
