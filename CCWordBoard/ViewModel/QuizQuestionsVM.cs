using CCWordBoard.Models;
using System.Collections.Generic;  

namespace CCWordBoard.ViewModel
{
        public class QuizQuestionsVM  
        {  
            public int VMQuizQuestionId { get; set; }  
            public string VMQuizQuestionText { get; set; }  
            public ICollection<QuizAnswersVM> VMQuizAnswers { get; set; }  
        }
}