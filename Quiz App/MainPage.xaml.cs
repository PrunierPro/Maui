using Quiz_App.Views;

namespace Quiz_App
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnQuizBtnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new QuizPage(1));
        }
    }
}