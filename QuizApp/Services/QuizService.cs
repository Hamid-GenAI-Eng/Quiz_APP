using Microsoft.EntityFrameworkCore;
using QuizApp.Data;
using QuizApp.DTOs;
using QuizApp.Models;

namespace QuizApp.Services
{
    public class QuizService
    {
        private readonly AppDbContext _context;

        public QuizService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<QuizQuestion>> GetRandomQuestionsAsync(int count = 10)
        {
            return await _context.QuizQuestions
                .OrderBy(q => Guid.NewGuid())
                .Take(count)
                .ToListAsync();
        }

        public async Task<int> CheckAnswersAsync(List<QuizAnswerDto> userAnswers)
        {
            int score = 0;

            foreach (var userAnswer in userAnswers)
            {
                var question = await _context.QuizQuestions.FindAsync(userAnswer.QuestionId);
                if (question != null && 
                    string.Equals(userAnswer.SelectedOption, question.CorrectOption, StringComparison.OrdinalIgnoreCase))
                {
                    score++;
                }
            }

            return score;
        }
    }
}
