using System;
using System.Linq;

namespace GeniyIdiot
{
    internal class Program
    {
        static void Main()
        {
            var restartTest = true;
            Console.WriteLine("Здравствуйте! Рады видеть вас на прохождении теста Гений и Идиот!");
            Console.Write("Введите свое имя: ");
            string userName = Console.ReadLine();
            while (restartTest)
            {
                var countQuestions = 5;
                string[] questions = GetQuestions(countQuestions);
                int[] answers = GetAnswers(countQuestions);
                var countRightAnswers = 0;
                var randomNumber = GetRandomNumber(0, countQuestions);
            
                for (int i = 0; i < countQuestions; i++)
                {
                    var randomQuestionIndex = randomNumber[i];
                    Console.WriteLine($"Вопрос №{i + 1}");
                    Console.WriteLine(questions[randomQuestionIndex]);

                    var userAnswer = Convert.ToInt32(Console.ReadLine());
                    var rightAnswer = answers[randomQuestionIndex];
                
                    if (userAnswer == rightAnswer)
                    {
                        countRightAnswers++;
                    }
                }
                Console.WriteLine("Количество правильных ответов: " + countRightAnswers);
                string diagnose = GetDiagnoses(countRightAnswers);
                Console.WriteLine($"{userName}, ваш диагноз: {diagnose}");
                
                Console.Write("Хотите пройти тест заново?(1 - да, 0 - нет) ");
                var answerTest = Console.ReadLine();
                while (true)
                {
                    if (answerTest == "0")
                    {
                        restartTest = false;
                    }
                    if (answerTest != "0" && answerTest != "1")
                    {
                        Console.WriteLine("Введите корректное значение(1 - да, 0 - нет)");
                        answerTest = Console.ReadLine();
                    }
                    else break;
                }
            }
            

        }

        static string GetDiagnoses(int countRightAnswers)
        {
            string[] diagnoses = new string[6];
            diagnoses[0] = "Идиот";
            diagnoses[1] = "Кретин";
            diagnoses[2] = "Дурак";
            diagnoses[3] = "Нормальный";
            diagnoses[4] = "Талант";
            diagnoses[5] = "Гений";
            return diagnoses[countRightAnswers];
        }
        static string[] GetQuestions(int countQuestions)
        {
            string[] questions = new string[countQuestions];
            questions[0] = "Сколько будет два плюс два умноженное на два?";
            questions[1] = "Бревно нужно разделить на 10 частей, сколько распилов нужно сделать?";
            questions[2] = "На двух руках 10 пальцев. Сколько будет пальцев на 5 руках?";
            questions[3] = "Укол делают каждые полчаса, сколько минут нужно на 3 укола?";
            questions[4] = "Пять свечей горело, две потухли. Сколько свечей осталось?";
            return questions;
        }

        static int[] GetAnswers(int countQuestions)
        {
            int[] answers = new int[countQuestions];
            answers[0] = 6;
            answers[1] = 9;
            answers[2] = 25;
            answers[3] = 60;
            answers[4] = 2;
            return answers;
        }

        static int[] GetRandomNumber(int minValue, int maxValue)
        {
            Random random = new Random();
            int[] numbers = Enumerable.Range(minValue, maxValue - minValue).ToArray();
            
            for (int i = numbers.Length - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                (numbers[i], numbers[j]) = (numbers[j], numbers[i]);
            }
            return numbers;
        }

    }
}
