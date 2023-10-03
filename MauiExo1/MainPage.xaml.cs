using System;

namespace MauiExo1
{
    public partial class MainPage : ContentPage
    {
        int number = 0;

        public MainPage()
        {
            InitializeComponent();
            number = GenerateMagicNumber();
        }

        private int GenerateMagicNumber()
        {
            Random rand = new Random();
            return rand.Next(21);
        }

        private void Guess(object sender, EventArgs e)
        {
            MessageLabel.SetValue(Label.TextColorProperty, Colors.White);
            int num = 0;
            try
            {
                num = int.Parse(((Entry)sender).Text);
                if (num < 1 || num > 20) throw new FormatException();
            }
            catch
            {
                MessageLabel.SetValue(Label.TextColorProperty, Colors.Red);
                MessageLabel.SetValue(Label.TextProperty, "You need to enter a number between 1 and 20.");
                return;
            }
            if (num == number)
            {
                MessageLabel.SetValue(Label.TextProperty, "Congratulations! You found the number!");
                MessageLabel.SetValue(Label.TextColorProperty, Colors.Green);
            }
            else
            {
                MessageLabel.SetValue(Label.TextColorProperty, Colors.Red);
                MessageLabel.SetValue(Label.TextProperty, "That wasn't the right number. Try again.");
            }
        }
    }
}