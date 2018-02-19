using CCWordBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCWordBoard.Helper
{
    public static class QuestionHelper
    {
        private static List<Question> _questions;

        public static List<Question> GetAllQuestions()
        {
            return _questions;
        }

        public static void LoadQuestions(String filename)
        {
            try
            {
                _questions = new List<Question>();

                Question currentQuestion = null;

                String[] lines = System.IO.File.ReadAllLines(filename);
                var linesOfQuestions = ArrangeLinesByQuestions(lines);
                foreach(var linesOfQuestion in linesOfQuestions)
                {
                    _questions.Add(new Question(linesOfQuestion));
                }

            } catch (Exception ex)
            {
                //TODO log
            }
        }

        public static List<List<String>> ArrangeLinesByQuestions(String[] lines)
        {
            var res = new List<List<string>>();
            List<string> current = null;
            foreach(var line in lines)
            {
                if (line.StartsWith("?"))
                {
                    if (current!=null)
                    {
                        res.Add(current);
                    }
                    current = new List<string>();
                }
                current.Add(line);
            }
            if (current != null)
            {
                res.Add(current);
            }
            return res;
        } 
    }
}
