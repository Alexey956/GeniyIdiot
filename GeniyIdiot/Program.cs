using System;
using System.IO;
using System.Linq;
using System.Text;

namespace GeniyIdiot
{
    internal class Program
    {
        static void Main()
        {
            var restartTest = true;
            Console.WriteLine("День Добрый! Вы попали на страницу проверки вашего IQ.Шучу, это тест Гений и Идиот");
            Console.Write("Введите свое имя и фамилию: ");
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
                    int userAnswer = GetUserAnswer();

                    int rightAnswer = answers[randomQuestionIndex];

                    if (userAnswer == rightAnswer)
                    {
                        countRightAnswers++;
                    }
                }
                Console.WriteLine("Количество правильных ответов: " + countRightAnswers);
                string diagnose = GetDiagnosesResult(countRightAnswers, countQuestions);
                Console.WriteLine($"{userName}, ваш диагноз: {diagnose}");

                SaveUserResult(userName, countRightAnswers, diagnose);
                
                bool userChoice = GetUserChoice("Хотите посмотреть предыдущие результаты игры?");
                if (userChoice)
                {
                    ShowUserResults();
                }
                
                userChoice = GetUserChoice("Хотите начать тест сначала?");

                if (userChoice == false)
                {
                    restartTest = false;
                }
            }
        }

        static void ShowUserResults()
        {
            StreamReader reader = new StreamReader("userResults.txt", Encoding.UTF8);
            
            Console.WriteLine("{0,-20}{1,20}{2,20}", "Имя","Кол- правильных ответов", "Диагноз");
            Console.WriteLine("-----------------------------------------------------------------");
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] values = line.Split('#');
                string name = values[0];
                int countRightAnswers = Convert.ToInt32(values[1]);
                string diagnose = values[2];

                Console.WriteLine("{0,-20}{1,15}{2,27}", name, countRightAnswers, diagnose);
            }
            reader.Close();
        }

        static void SaveUserResult(string userName, int countRightAnswers, string diagnose)
        {
            string value = $"{userName}#{countRightAnswers}#{diagnose}";
            AppendToFile("userResults.txt", value);
        }

        static void AppendToFile(string fileName, string value)
        {
            StreamWriter writer = new StreamWriter(fileName, true, Encoding.UTF8);
            writer.WriteLine(value);
            writer.Close();
        }
        private static int GetUserAnswer()
        {
            while (true)
            {
                try
                {
                    return Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Введите число");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Введите число от -2*10^9 до 2*10^9!");
                }
            }
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
