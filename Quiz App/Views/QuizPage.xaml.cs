using Quiz_App.Models;
using Quiz_App.Resources.Questions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_App.Views
{
    public partial class QuizPage : ContentPage
    {
        private int _num;
        private static Random rand = new Random();
        private static List<Question> Questions = QuestionStorage.Questions();
        private static List<Question> UsedQuestions = new List<Question>();
        private Question _currentQuestion;

        public QuizPage(int num)
        {
            InitializeComponent();
            if (num < 11)
            {
                //Choose random question
                _num = num;
                QuestionNum.SetValue(Label.TextProperty, $"Question {_num}/10");
                do
                {
                    _currentQuestion = Questions[rand.Next(Questions.Count)];
                } while (UsedQuestions.Contains(_currentQuestion));
                UsedQuestions.Add(_currentQuestion);

                //Set prompt and show entry or 4 options depending on question
                Prompt.SetValue(Label.TextProperty, _currentQuestion.Prompt);
                string[] answerArray = new string[_currentQuestion.Answers.Count];
                _currentQuestion.Answers.CopyTo(answerArray);
                List<string> answers = new List<string>(answerArray);
                List<Button> buttons = new List<Button>() { OptionOne, OptionTwo, OptionThree, OptionFour };
                if (answers.Count > 1)
                {
                    foreach (Button b in buttons)
                    {
                        string answer = answers[rand.Next(answers.Count)];
                        b.SetValue(Button.TextProperty, answer);
                        b.SetValue(Button.IsVisibleProperty, true);
                        answers.Remove(answer);
                    }
                }
                else
                {
                    AnswerEntry.SetValue(Entry.IsVisibleProperty, true);
                }
            } else 
            {
                Prompt.SetValue(IsVisibleProperty, false);
                QuestionNum.SetValue(IsVisibleProperty, false);
                WinLabel.SetValue(IsVisibleProperty, true);
                ReturnBtn.SetValue(IsVisibleProperty, true);
                NerdImg.SetValue(IsVisibleProperty, true);
                NerdLabel.SetValue(IsVisibleProperty, true);
            }
        }

        public async void OnEntryAnswer(object sender, EventArgs e)
        {
            CheckAnswer(((Entry)sender).Text);
        }

        public async void OnBtnAnswer(object sender, EventArgs e)
        {
            CheckAnswer(((Button)sender).Text);
        }

        private async void CheckAnswer(string answer)
        {
            try
            {
                if (_currentQuestion.Guess(answer))
                {
                    await Navigation.PushAsync(new QuizPage(_num+1));
                }
                else
                {
                    UsedQuestions.Remove(_currentQuestion);
                    await Navigation.PopAsync();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.StackTrace);
                await Navigation.PopToRootAsync();
            }
        }

        public async void OnReturnClicked(object sender, EventArgs e)
        {
            UsedQuestions = new List<Question>();
            await Navigation.PopToRootAsync();
        }

    }
}
