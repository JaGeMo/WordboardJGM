using System.Collections.Generic;
using System.Linq;
using CCWordBoard.Helper;
using CCWordBoard.Models;
using CCWordBoard.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CCWordBoard.Controllers
{
    public class QuizController : Controller
    {
        // read file content and show all questions
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        
        // read file content and show all questions
        [HttpGet]
        public IActionResult SelectAnswers()
        {
            QuizHelper.LoadDataFromFile(".//Data//Questions.txt");
            var quizQuestions = QuizHelper.GetAllQuizQuestions();
            var rawQuizAnswers = QuizHelper.GetAllQuizAnswers();
            
            IQueryable<QuizQuestionsVM> questionsInclAnswers = null;
            
            questionsInclAnswers = quizQuestions.Where(q => q.QuizQuestionId != null)
                .Select(q => new QuizQuestionsVM
                {
                    VMQuizQuestionId = q.QuizQuestionId,
                    VMQuizQuestionText = q.QuizQuestionText,
                    VMQuizAnswers = rawQuizAnswers.Where(a => a.QuizQuestionId == q.QuizQuestionId)
                        .Select(c => new QuizAnswersVM{
                            QuizAnswerId = c.QuizAnswerId,
                            QuizAnswerText = c.QuizAnswerText,
                            QuizQuestionID = c.QuizQuestionId
                        }).ToList()
                }).AsQueryable();
            
            
            return View(questionsInclAnswers);
        }
        
        // process answers
        [HttpPost]
        public IActionResult SelectAnswers(List<QuizAnswersVM> resultQuiz)
        {
            var correctQuizAnswers = QuizHelper.GetAllCorrectQuizAnswers();
            List<QuizCorrectAnswerVM> finalResultQuiz = new List<CCWordBoard.ViewModel.QuizCorrectAnswerVM>();  
  
            foreach(QuizAnswersVM answer in resultQuiz)  
            {  
                QuizCorrectAnswerVM result = correctQuizAnswers.Where(a => a.QuizQuestionId == answer.QuizQuestionID ).Select(a => new QuizCorrectAnswerVM() 
                {  
                    QuizQuestionID  = a.QuizQuestionId,
                    QuizAnswerCorrect = a.QuizCorrectAnswerText,  
                    isCorrect = (answer.QuizAnswerText).Equals(a.QuizCorrectAnswerText) 
                    
                }).FirstOrDefault();  
  
                finalResultQuiz.Add(result);  
            }  
  
            return Json(new { result = finalResultQuiz });  
        }
    }
}