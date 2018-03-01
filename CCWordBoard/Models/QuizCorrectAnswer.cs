namespace CCWordBoard.Models
{
    public class QuizCorrectAnswer
    {
        public int QuizCorrectAnswerId { get; set; }

        public string QuizCorrectAnswerText { get; set; }

        public int QuizQuestionId { get; set; }
    }
}