using System.Text.Json;

namespace TriviaQuiz
{
    //https://the-trivia-api.com/v2/questions - API to get questions
    public partial class MainPage : ContentPage
    {
        private TriviaQuestion triviaQuestions; // List of trivia questions (you need to populate this)


        public MainPage()
        {
            InitializeComponent();
        }
      

        private async void LoadQuestion(int index)
        {
            string URL = "https://the-trivia-api.com/v2/questions";
           // Fetch weather data from the API
                Console.WriteLine("API URL: " + URL);
                triviaQuestions = await GetQuestionDataAsync(URL);
                Console.WriteLine("API Response: " + JsonSerializer.Serialize(triviaQuestions));

            // Update the UI with weather information
            if (triviaQuestions != null)
            {
                QuestionLabel.Text = triviaQuestions.CorrectAnswer;
                Console.WriteLine("Latitude: " + triviaQuestions.question.Text);
                Console.WriteLine("Latitude: " + triviaQuestions.ID);
                Console.WriteLine("Latitude: " + triviaQuestions.Category);
                Console.WriteLine("Latitude: " + triviaQuestions.CorrectAnswer);
             
                //Option1Button.Text = currentQuestion.Options[0];
                //Option2Button.Text = currentQuestion.Options[1];
                //Option3Button.Text = currentQuestion.Options[2];
                //Option4Button.Text = currentQuestion.Options[3];
            }                 
        }

        private void OptionButton_Clicked(object sender, EventArgs e)
        {
            // Check if the selected option is correct and handle accordingly
            var selectedOption = (sender as Button).Text;
            //var currentQuestion = triviaQuestions[currentQuestionIndex];
            //if (selectedOption == currentQuestion.CorrectAnswer)
            //{
            //    // Correct answer handling
            //    // You can implement the logic here, such as showing a "Correct!" label or adding points to the user's score.
            //}
            //else
            //{
            //    // Incorrect answer handling
            //    // You can implement the logic here, such as showing a "Wrong!" label or deducting points from the user's score.
            //}

            // Move to the next question
            //currentQuestionIndex++;
            //if (currentQuestionIndex < triviaQuestions.Count)
            //    LoadQuestion(currentQuestionIndex);
            //else
            //{
            //    // Quiz completed handling
            //    // You can display the final score or a message that the quiz is completed.
            //}
        }

        private async Task<TriviaQuestion> GetQuestionDataAsync(string apiUrl)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    TriviaQuestion QuestionData = JsonSerializer.Deserialize<TriviaQuestion>(content);
                    return QuestionData;
                }

                return null;
            }
        }
    }   
}
