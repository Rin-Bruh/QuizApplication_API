using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QuizApplication_QuizAPI.Models
{
	public class User
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int UserId { get; set; }

		[Required]
		[MaxLength(200)]
		public string Username { get; set; } = string.Empty;

		[Required]
		[MaxLength(255)]
		public string Email { get; set; } = string.Empty;

		public virtual ICollection<QuizAttempt> QuizAttempts { get; set; } = new List<QuizAttempt>();
	}
}
