using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QuizApplication_QuizAPI.Models
{
	public class Question
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int QuestionId { get; set; }

		[ForeignKey("Quiz")]
		public int QuizId { get; set; }

		[Required]
		[MaxLength(200)]
		public string QuestionText { get; set; } = string.Empty;

		public virtual Quiz Quiz { get; set; } = null!;
		public virtual ICollection<AnswerOption> AnswerOptions { get; set; } = new List<AnswerOption>();
		public virtual ICollection<UserAnswer> UserAnswers { get; set; } = new List<UserAnswer>();
	}
}
