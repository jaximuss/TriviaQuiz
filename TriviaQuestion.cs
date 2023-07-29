using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaQuiz
{
    /// <summary>
    /// create the models for the questions
    /// </summary>
    public class TriviaQuestion
    {
        public string Question { get; set; }
        public string CorrectAnswer { get; set; }
        public List<string> Options { get; set; }
    }
}
