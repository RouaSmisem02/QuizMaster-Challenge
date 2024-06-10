using System;
using System.Threading;

namespace QuizMaster_Challenge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Quiz Master Challenge:");

            try
            {
                StartQuiz();
            }
            catch (OverflowException OverflowEx)
            {
                Console.WriteLine("An overflow exception occurred: " + OverflowEx.Message);
            }
            catch (FormatException formatEx)
            {
                Console.WriteLine("A format exception occurred: " + formatEx.Message);
            }
            catch (ArgumentException ArgumentEx)
            {
                Console.WriteLine("An argument exception occurred: " + ArgumentEx.Message);
            }
            catch (InvalidOperationException InvalidOperationEx)
            {
                Console.WriteLine("An invalid operation exception occurred: " + InvalidOperationEx.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Quiz completed.");
            }
        }

        static void StartQuiz()
        {
            Console.WriteLine("You will face questions in different majors: Math, Capitals of the cities, and Programming.");
            Console.WriteLine("Each question has a 10-second timer.");

            // Initialize questions with labels
            string[] questions = new string[]
            {
                "Math: What is the result of 5 + 7?",
                "Math: What is 15 - 9?",

                "Capitals: What is the capital of Jordan?",
                "Capitals: What is the capital of Syria?",

                "Programming: What is the output of the code snippet 'Console.WriteLine(\"Hello, World!\");' in C#?"
            };

            // Initialize answers
            string[] answers = new string[]
            {
                "12",
                "6",

                "Amman",
                "Damascus",

                "Hello, World!"
            };

            int score = 0;

            for (int i = 0; i < questions.Length; i++)
            {
                Console.WriteLine($"Question {i + 1}: {questions[i]}");

                bool answered = false;
                var timer = new Timer(state =>
                {
                    if (!answered)
                    {
                        Console.WriteLine("\nTime's up!");
                        Console.WriteLine($"The correct answer is: {answers[i]}\n");
                        answered = true; 
                    }
                }, null, 10000, Timeout.Infinite);

                Console.Write("Your answer: ");
                string userAnswer = Console.ReadLine();

                timer.Change(Timeout.Infinite, Timeout.Infinite);

                if (string.IsNullOrEmpty(userAnswer))
                {
                    Console.WriteLine("Please enter an answer.");
                    i--; 
                    continue;
                }

                
                if (!answered)
                {
                    if (userAnswer.Trim().ToLower() == answers[i].ToLower())
                    {
                        Console.WriteLine("Correct!\n");
                        score++;
                    }
                    else
                    {
                        Console.WriteLine($"Not a correct answer! The correct answer is ({answers[i]})\n");
                    }
                }

            }

            Console.WriteLine($"Your final score is {score} out of {questions.Length}.");
        }
    }
}
