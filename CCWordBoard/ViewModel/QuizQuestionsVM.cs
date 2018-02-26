using CCWordBoard.Models;
using System.Collections.Generic;  

namespace CCWordBoard.ViewModel
{
        public class QuizQuestionsVM  
        {  
            public int QuizQuestionId { get; set; }  
            public string QuizQuestionText { get; set; }  
            public  ICollection<QuizAnswersVM> QuizAnswers { get; set; }  
        }
}