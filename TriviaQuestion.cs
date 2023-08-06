using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TriviaQuiz
{
    /// <summary>
    /// create the models for the questions and setting up the API
    /// </summary>
    public class TriviaQuestion
    {
        [JsonPropertyName("category")]
        public string Category { get; set; }

        [JsonPropertyName("id")]
        public string ID { get; set; }

        [JsonPropertyName("correctAnswer")]
        public string CorrectAnswer { get; set; }

        [JsonPropertyName("incorrectAnswers")]
        public List<string> Options { get; set; }

        [JsonPropertyName("question")]
        public Questions question { get; set; }

        [JsonPropertyName("tags")]
        public List<string> Tags { get; set; }


        [JsonPropertyName("difficulty")]
        public string Difficulty { get; set; }
    }
    public class Questions
    {
        [JsonPropertyName("text")]
        public string Text { get; set; }
    }


}
