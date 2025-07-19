
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuizApp.DTOs;
using QuizApp.Services;

namespace QuizApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class QuizController : ControllerBase
    {
        private readonly QuizService _quizService;

        public QuizController(QuizService quizService)
        {
            _quizService = quizService;
        }

        [HttpGet("get-random")]
        public async Task<IActionResult> GetRandomQuizQuestions()
        {
            var questions = await _quizService.GetRandomQuestionsAsync();
            return Ok(questions);
        }

        [HttpPost("submit")]
        public async Task<IActionResult> SubmitQuiz([FromBody] QuizSubmissionDto dto)
        {
            int score = await _quizService.CheckAnswersAsync(dto.Answers);
            return Ok(new { message = "Quiz submitted successfully.", score });
        }
    }
}
