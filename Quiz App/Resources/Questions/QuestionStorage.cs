using Quiz_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_App.Resources.Questions
{
    internal class QuestionStorage
    {
        public static List<Question> Questions()
        {
            return new List<Question>()
            {
                new Question("2 + 2 = ?", new string[]{"4", "2", "8", "128"}),
                new Question("5 + 8 = ?", new string[]{"13"}),
                new Question("6 + 12 = ?", new string[]{"18"}),
                new Question("4 + 13 = ?", new string[]{"17"}),
                new Question("6 x 6 = ?", new string[]{"36", "64", "600", "6"}),
                new Question("400 + 20 = ?", new string[]{"420", "42", "240", "69"}),
                new Question("600 + 60 + 6 = ?", new string[]{"666", "600606", "6", "777"}),
                new Question("123456789 / 0 = ?", new string[]{"Impossible", "123456789", "0", "4.5345213"}),
                new Question("123456789 / 1 = ?", new string[]{"123456789"}),
                new Question("(985 + 15) x (456 + 544) - 1000000 = ?", new string[]{"0", "98515456", "432456563", "10000000"}),
                new Question("2(8) + 1 = ?", new string[]{"17", "34", "67", "29"}),
                new Question("√4 = ?", new string[]{"2", "1", "0", "4"}),
                new Question("√16 = ?", new string[]{"4"}),
                new Question("0, 1, 1, 2, 3, 5, 8, 13, 21, ?", new string[]{"34", "55", "89", "144"}),
                new Question("0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, ?", new string[]{"89"}),
                new Question("7, 5, 8, 4, 9, 3, ?", new string[]{"10", "3", "11", "7"}),
                new Question("7, 5, 8, 4, 9, 3, 10, 2, ?", new string[]{"11"}),
            };
        }
    }
}
