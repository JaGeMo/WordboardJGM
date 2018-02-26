using System;
using System.Collections.Generic;
using CCWordBoard.Models;

namespace CCWordBoard.Helper
{
    public static class QuizHelper
    {
        private static List<QuizQuestion> _quizQuestions;
        private static int quizQuestionIndex = 0;
        private static int quizAnswerIndex = 0;

        public static List<QuizAnswer> _quizAnswers;

        public static List<QuizQuestion> GetAllQuizQuestions()
        {
            return _quizQuestions;
        }

        public static List<QuizAnswer> GetAllQuizAnswers()
        {
            return _quizAnswers;
        }
        
        public static void LoadDataFromFile(String filename)
        {
            try
            {
                _quizQuestions = new List<QuizQuestion>();
                _quizAnswers = new List<QuizAnswer>();
               
                String[] lines = System.IO.File.ReadAllLines(filename);
                foreach (var line in lines)
                {
                    if (line.StartsWith("?"))
                    {
                        var quizQuestion = new QuizQuestion();
                        quizQuestion.QuizQuestionId = ++quizQuestionIndex;
                        quizQuestion.QuizQuestionText = line.Substring(1);
                        _quizQuestions.Add(quizQuestion);
                    }
                    else
                    {
                        var quizAnswer = new QuizAnswer();
                        quizAnswer.QuizAnswerId = ++quizAnswerIndex;
                        quizAnswer.QuizAnswerText = line.StartsWith("*") ? line.Substring(1) : line;
                        quizAnswer.QuizQuestionId = quizQuestionIndex;
                        quizAnswer.QuizCorrectAnswer = line.StartsWith("*") ? true : false;
                        _quizAnswers.Add(quizAnswer);
                    }
                }
            }
            catch (Exception ex)
            {
                //TODO log
            }
        }
    }
}
