namespace CCWordBoard.Models
{
    public class QuizAnswer
    {
        public int QuizAnswerId { get; set; }

        public string QuizAnswerText { get; set; }

        public int QuizQuestionId { get; set; }

        public bool QuizCorrectAnswer { get; set; }
    }
}