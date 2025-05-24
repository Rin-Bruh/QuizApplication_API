using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QuizApplication_QuizAPI.Models
{
	public class QuizAttempt
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int AttemptId { get; set; }

		[ForeignKey("User")]
		public int UserId { get; set; }

		[ForeignKey("Quiz")]
		public int QuizId { get; set; }
		public DateTime StartTime { get; set; }
		public DateTime? EndTime { get; set; }
		public decimal Score { get; set; }
		public bool Passed { get; set; }
		public DateTime CreatedAt { get; set; }

		public virtual User User { get; set; } = null!;
		public virtual Quiz Quiz { get; set; } = null!;
		public virtual ICollection<UserAnswer> UserAnswers { get; set; } = new List<UserAnswer>();
	}
}
