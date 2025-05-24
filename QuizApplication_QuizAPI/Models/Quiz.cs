using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QuizApplication_QuizAPI.Models
{
	public class Quiz
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int QuizId { get; set; }

		[Required]
		[MaxLength(200)]
		public string QuizTitle { get; set; } = string.Empty;

		[Required]
		public int TotalQuestion { get; set; }

		public int TimeLimitMinute { get; set; }

		[Required]
		public decimal PassingScore { get; set; }

		public virtual ICollection<Question> Questions { get; set; } = new List<Question>();
		public virtual ICollection<QuizAttempt> QuizAttempts { get; set; } = new List<QuizAttempt>();
	}
}
