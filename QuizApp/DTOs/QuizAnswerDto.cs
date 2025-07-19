namespace QuizApp.DTOs
{
    public class QuizAnswerDto
    {
        public int QuestionId { get; set; }
        public string SelectedOption { get; set; } = string.Empty; // "A", "B", "C", "D"
    }
}
