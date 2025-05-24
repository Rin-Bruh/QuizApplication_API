using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QuizApplication_QuizAPI.Models
{
	public class UserAnswer
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int UserAnswerId { get; set; }

		[ForeignKey("QuizAttempt")]
		public int AttemptId { get; set; }

		[ForeignKey("Question")]
		public int QuestionId { get; set; }

		[ForeignKey("AnswerOption")]
		public int SelectedOptionId { get; set; }
		public bool IsCorrect { get; set; }

		public virtual QuizAttempt QuizAttempt { get; set; } = null!;
		public virtual Question Question { get; set; } = null!;
		public virtual AnswerOption SelectedOption { get; set; } = null!;
	}
}
