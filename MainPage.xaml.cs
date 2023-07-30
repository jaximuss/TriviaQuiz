using System.Text.Json;

namespace TriviaQuiz
{

    public partial class MainPage : ContentPage
    {
        private TriviaViewModel viewModel;

        public MainPage()
        {
            InitializeComponent();

            viewModel = (TriviaViewModel)BindingContext;
            LoadNextQuestion();

        }

        private async void OnNextQuestionClicked(object sender, EventArgs e)
        {
            await LoadNextQuestion();
        }

        private void OnOptionClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            viewModel.SelectedAnswer = button.Text;
        }

        private async Task LoadNextQuestion()
        {
            await viewModel.LoadNextQuestion();
        }

    }
}
