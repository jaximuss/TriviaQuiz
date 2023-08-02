using System.Text.Json;

namespace TriviaQuiz
{

    public partial class MainPage : ContentPage
    {
        private List<TriviaQuestion> triviaQuestions; // List of trivia questions (you need to populate this)

        private int currentQuestionIndex = 0;

        public MainPage()
        {
            InitializeComponent();
            LoadQuestion(currentQuestionIndex);
        }

        private void LoadQuestion(int index)
        {
            var currentQuestion = triviaQuestions[index];
            QuestionLabel.Text = currentQuestion.question.Text;
            Option1Button.Text = currentQuestion.Options[0];
            Option2Button.Text = currentQuestion.Options[1];
            Option3Button.Text = currentQuestion.Options[2];
            Option4Button.Text = currentQuestion.Options[3];
        }

        private void OptionButton_Clicked(object sender, EventArgs e)
        {
            // Check if the selected option is correct and handle accordingly
            var selectedOption = (sender as Button).Text;
            var currentQuestion = triviaQuestions[currentQuestionIndex];
            if (selectedOption == currentQuestion.CorrectAnswer)
            {
                // Correct answer handling
                // You can implement the logic here, such as showing a "Correct!" label or adding points to the user's score.
            }
            else
            {
                // Incorrect answer handling
                // You can implement the logic here, such as showing a "Wrong!" label or deducting points from the user's score.
            }

            // Move to the next question
            currentQuestionIndex++;
            if (currentQuestionIndex < triviaQuestions.Count)
                LoadQuestion(currentQuestionIndex);
            else
            {
                // Quiz completed handling
                // You can display the final score or a message that the quiz is completed.
            }
        }
    }   
}
