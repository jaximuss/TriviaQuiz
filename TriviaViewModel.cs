using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TriviaQuiz
{
    public class TriviaViewModel : INotifyPropertyChanged
    {

        private ObservableCollection<string> options;
        public ObservableCollection<string> Options
        {
            get { return options; }
            set
            {
                options = value;
                OnPropertyChanged(nameof(Options));
            }
        }

        private string questionText;
        public string QuestionText
        {
            get { return questionText; }
            set
            {
                questionText = value;
                OnPropertyChanged(nameof(QuestionText));
            }
        }

        private string correctAnswer;
        public string CorrectAnswer
        {
            get { return correctAnswer; }
            set
            {
                correctAnswer = value;
                OnPropertyChanged(nameof(CorrectAnswer));
            }
        }

        private string selectedAnswer;
        public string SelectedAnswer
        {
            get { return selectedAnswer; }
            set
            {
                selectedAnswer = value;
                OnPropertyChanged(nameof(SelectedAnswer));
            }
        }

        private HttpClient httpClient;

        public TriviaViewModel()
        {
            Options = new ObservableCollection<string>();
            httpClient = new HttpClient();
        }

        public async Task LoadNextQuestion()
        {
            var response = await httpClient.GetAsync("https://the-trivia-api.com/v2/questions");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var questions = JsonSerializer.Deserialize<List<TriviaQuestion>>(content);
                if (questions != null && questions.Count > 0)
                {
                    var question = questions[0]; // Get the first question from the list
                    QuestionText = question.question.Text;
                    Options.Clear();
                    Options.Add(question.CorrectAnswer);

                    // Use a loop to add the incorrect answers one by one
                    foreach (var incorrectAnswer in question.Options)
                    {
                        Options.Add(incorrectAnswer);
                    }

                    CorrectAnswer = question.CorrectAnswer;
                    SelectedAnswer = null;
                }
            }
        }

        public bool CheckAnswer()
        {
            return SelectedAnswer == CorrectAnswer;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
