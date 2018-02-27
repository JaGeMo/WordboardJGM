namespace CCWordBoard.ViewModel
{
    public class QuizCorrectAnswerVM
    {
        public int QuizAnswerId { get; set; }
        public string QuizAnswerCorrect { get; set; }
        public int QuizQuestionID { get; set; }
        public bool isCorrect { get; set; }
    }
}