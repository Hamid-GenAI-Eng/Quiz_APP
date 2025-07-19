namespace QuizApp.DTOs
{
    public class QuizSubmissionDto
    {
        public List<QuizAnswerDto> Answers { get; set; } = new();
    }
}

