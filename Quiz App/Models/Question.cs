using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_App.Models
{
    public class Question
    {

        public string Prompt { get; set; }
        public List<string> Answers { get; set; }

        public Question(string prompt, string[] answers)
        {
            Prompt = prompt;
            Answers = new List<string>(answers);
        }

        public bool Guess(string guess)
        {
            return guess.ToLower().Equals(Answers[0].ToLower()); //Correct answer will always be stored first in the table
        }
    }
}
