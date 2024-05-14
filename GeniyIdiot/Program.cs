using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeniyIdiot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] questions = new string[5];
            questions[0] = "Сколько будет два плюс два умноженное на два?";
            questions[1] = "Бревно нужно разделить на 10 частей, сколько распилов нужно сделать?";
            questions[2] = "На двух руках 10 пальцев. Сколько будет пальцев на 5 руках?";
            questions[3] = "Укол делают каждые полчаса, сколько минут нужно на 3 укола?";
            questions[4] = "Пять свечей горело, две потухли. Сколько свечей осталось?";

            int[] answers = new int[5];
            answers[0] = 6;
            answers[1] = 9;
            answers[2] = 25;
            answers[3] = 60;
            answers[4] = 2;

            int countRightAnswers = 0;

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(questions[i]);

                int userAnswer = Convert.ToInt32(Console.ReadLine());

                int rightAnswer = answers[i];

                if (userAnswer == rightAnswer)
                {
                    countRightAnswers++;
                }
            }
            
            Console.WriteLine("Количество правильных ответов: " + countRightAnswers);
        }
    }
}
