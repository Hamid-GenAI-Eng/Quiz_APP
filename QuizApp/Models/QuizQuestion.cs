using System.ComponentModel.DataAnnotations;

namespace QuizApp.Models
{
    public class QuizQuestion
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Question { get; set; } = string.Empty;

        [Required]
        public string OptionA { get; set; } = string.Empty;
        [Required]
        public string OptionB { get; set; } = string.Empty;
        [Required]
        public string OptionC { get; set; } = string.Empty;
        [Required]
        public string OptionD { get; set; } = string.Empty;

        [Required]
        public string CorrectOption { get; set; } = string.Empty; // "A", "B", "C", "D"
    }
}
