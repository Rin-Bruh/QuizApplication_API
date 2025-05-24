using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QuizApplication_QuizAPI.Models
{
	public class AnswerOption
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int OptionId { get; set; }

		[ForeignKey("Question")]
		public int QuestionId { get; set; }

		[Required]
		[MaxLength(300)]
		public string OptionText { get; set; } = string.Empty;

		public bool IsCorrect { get; set; }

		public virtual Question Question { get; set; } = null!;
		public virtual ICollection<UserAnswer> UserAnswers { get; set; } = new List<UserAnswer>();
	}
}
