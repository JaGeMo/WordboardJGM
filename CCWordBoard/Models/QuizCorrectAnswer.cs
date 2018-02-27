namespace CCWordBoard.Models
{
    public class QuizCorrectAnswer
    {
        public int QuizCorrectAnswerId { get; set; }

        public string QuizAnswerText { get; set; }

        public int QuizQuestionId { get; set; }
    }
}