using Microsoft.AspNetCore.Mvc;
using QuizApplication_QuizAPI.Models.DTOs;
using QuizApplication_QuizAPI.Repository.IRepository;

namespace QuizApplication_QuizAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class QuizAPIController : ControllerBase
	{
		private readonly IQuizRepository _dbQuiz;
		public QuizAPIController(IQuizRepository dbQuiz)
		{
			_dbQuiz = dbQuiz;
		}

		[HttpGet("{quizId}/questions")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<List<QuestionDTO>>> GetQuizQuestions(int quizId)
		{
			try
			{
				var questions = await _dbQuiz.GetQuizQuestionsAsync(quizId);

				if (!questions.Any())
				{
					return NotFound($"No questions found for quiz with ID {quizId}");
				}

				return Ok(questions);
			}
			catch (Exception ex)
			{
				return BadRequest($"Error retrieving questions: {ex.Message}");
			}
		}

		[HttpPost("validate-answer")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]

		public async Task<ActionResult<AnswerValidationDTO>> ValidateAnswer([FromBody] AnswerSubmissionDTO submission)
		{
			try
			{
				var result = await _dbQuiz.ValidateAnswerAsync(submission);
				return Ok(result);
			}
			catch (ArgumentException ex)
			{
				return BadRequest(ex.Message);
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Error validating answer: {ex.Message}");
			}
		}

		[HttpGet("results/{attemptId}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]

		public async Task<ActionResult<QuizResultDTO>> GetQuizResults(int attemptId)
		{
			try
			{
				var result = await _dbQuiz.GetQuizResultAsync(attemptId);
				return Ok(result);
			}
			catch (ArgumentException ex)
			{
				return NotFound(ex.Message);
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Error retrieving quiz results: {ex.Message}");
			}
		}
	}
}
