namespace CCWordBoard.ViewModel
{
    public class QuizAnswersVM
    {
        public int QuizAnswerId { get; set; }
        public string QuizAnswerText { get; set; }
        public bool QuizCorrectAnswer { get; set; }
        public int QuizQuestionID { get; set; }
    }
}