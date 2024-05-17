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

                    while (true)
                    {
                        var answer = Console.ReadLine();

                        bool resulAnswer = int.TryParse(answer, out var userAnswers);
                        if (resulAnswer == true)
                        {
                            var rightAnswer = answers[randomQuestionIndex];

                            if (userAnswers == rightAnswer)
                            {
                                countRightAnswers++;
                            }
                            break;
                        }

                        Console.WriteLine("Введите числовое значение");
                    }
                }
                Console.WriteLine("Количество правильных ответов: " + countRightAnswers);
                string diagnose = GetDiagnosesResult(countRightAnswers, countQuestions);
                Console.WriteLine($"{userName}, ваш диагноз: {diagnose}");

                bool userChoice = GetUserChoice("Хотите начать тест сначала?");

                if (userChoice == false)
                {
                    restartTest = false;
                }
            }
        }
        static string[] GetDiagnoses()
        {
            var countDiagnoses = 6;
            string[] diagnoses = new string[6];
            diagnoses[0] = "Идиот";
            diagnoses[1] = "Кретин";
            diagnoses[2] = "Дурак";
            diagnoses[3] = "Нормальный";
            diagnoses[4] = "Талант";
            diagnoses[5] = "Гений";
            return diagnoses;
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

        static bool GetUserChoice(string message)
        {
            while (true)
            {
                Console.WriteLine(message + " Введите Да или Нет");
                var answerTest = Console.ReadLine();
                if (answerTest.ToLower() == "нет")
                {
                    return false;
                }
                if (answerTest.ToLower() == "да")
                {
                    return true;
                }
                Console.WriteLine("Недопустимый ввод. Пожалуйста введите Да или Нет.");
            }
        }

        /// <summary>
        /// Метод расчета диагноза
        /// </summary>
        /// <param name="countResult">Количество правильных ответов</param>
        /// <param name="countQuestion">Общее количество вопросов в тесте</param>
        /// <returns></returns>
        static string GetDiagnosesResult(int countResult, int countQuestion)
        {
            double ratioRightAnswer = (double)countResult/countQuestion;

            if (ratioRightAnswer == 0)
            {
                return "Идиот";
            }
            if (ratioRightAnswer > 0 && ratioRightAnswer < 0.25)
            {
                return "Кретин";
            }
            if (ratioRightAnswer >= 0.25 && ratioRightAnswer < 0.45)
            {
                return "Дурак";
            }
            if (ratioRightAnswer >= 0.45 && ratioRightAnswer < 0.65)
            {
                return "Нормальный";
            }
            if (ratioRightAnswer >= 0.65 && ratioRightAnswer < 0.85)
            {
                return "Талант";
            }
            return "Гений";
        }

    }
}
