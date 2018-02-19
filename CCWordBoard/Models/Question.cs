using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCWordBoard.Models
{
    public class Question
    {
        public Question(List<string> linesOfQuestion)
        {
            var answers = new List<String>();

            foreach (var line in linesOfQuestion)
            {
                if (line.StartsWith("?"))
                {
                    QuestionText = line.Substring(1);
                } else
                {
                    answers.Add(line);
                }
            }
            Answers = answers;
        }

        public String QuestionText { get; set; }

        public IEnumerable<String> Answers { get; set; }

        
    }
}
