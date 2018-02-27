using System;
using System.Collections.Generic;
using CCWordBoard.Models;

namespace CCWordBoard.Helper
{
    public static class QuizHelper
    {
        private static List<QuizQuestion> _quizQuestions;
        private static List<QuizAnswer> _quizAnswers;
        private static List<QuizCorrectAnswer> _quizCorrectAnswers;
            
        private static int quizQuestionIndex = 0;
        private static int quizAnswerIndex = 0;


        public static List<QuizQuestion> GetAllQuizQuestions()
        {
            return _quizQuestions;
        }

        public static List<QuizAnswer> GetAllQuizAnswers()
        {
            return _quizAnswers;
        }

        public static List<QuizCorrectAnswer> GetAllCorrectQuizAnswers()
        {
            return _quizCorrectAnswers;
        }

        
        
        public static void LoadDataFromFile(String filename)
        {
            try
            {
                _quizQuestions = new List<QuizQuestion>();
                _quizAnswers = new List<QuizAnswer>();
                _quizCorrectAnswers = new List<QuizCorrectAnswer>();
               
                String[] lines = System.IO.File.ReadAllLines(filename);
                foreach (var line in lines)
                {
                    if (line.StartsWith("?"))
                    {
                        var quizQuestion = new QuizQuestion();
                        quizQuestion.QuizQuestionId = ++quizQuestionIndex;
                        quizQuestion.QuizQuestionText = System.String.Concat(line.Substring(1),"?");
                        _quizQuestions.Add(quizQuestion);
                    }
                    else if(line.StartsWith("*"))
                    {
                        var quizAnswer = new QuizAnswer();
                        quizAnswer.QuizAnswerId = ++quizAnswerIndex;
                        quizAnswer.QuizAnswerText = line.Substring(1);
                        quizAnswer.QuizQuestionId = quizQuestionIndex;
                        _quizAnswers.Add(quizAnswer);
                        
                        var quizCorrectAnswer = new QuizCorrectAnswer();
                        quizCorrectAnswer.QuizCorrectAnswerId = quizAnswer.QuizAnswerId;
                        quizCorrectAnswer.QuizAnswerText = quizAnswer.QuizAnswerText;
                        quizCorrectAnswer.QuizQuestionId = quizAnswer.QuizQuestionId;
                        _quizCorrectAnswers.Add(quizCorrectAnswer);
                    }
                    else
                    {
                        var quizAnswer = new QuizAnswer();
                        quizAnswer.QuizAnswerId = ++quizAnswerIndex;
                        quizAnswer.QuizQuestionId = quizQuestionIndex;
                        _quizAnswers.Add(quizAnswer);
                        quizAnswer.QuizAnswerText = line.StartsWith("*") ? line.Substring(1) : line;
                    }
                }
            }
            catch (Exception ex)
            {
                //TODO 
            }
        }
    }
}
