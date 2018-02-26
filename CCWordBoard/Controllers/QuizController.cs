using Microsoft.AspNetCore.Mvc;

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
            return View();
        }
        
        // process answers
//        [HttpPost]
//        public IActionResult SelectAnswers()
//        {
//            return RedirectToAction("QuizTest"); 
//        }

        // return result string for output
//        [HttpPost]
//        public IActionResult QuizTest()
//        {
//            return Json( )    
//        }
        
    }
}