using System;

namespace AboutMeQuiz
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create question list from JSON and then ask the user all
            // of the questions
            QuestionList questions = QuestionList.FromJSON("questions.json");
            (int correct, int total) = questions.AskConsoleAll();
            double percentage = 100.0 * ((double)correct / total);

            // Provide the user with his/her results
            Console.WriteLine($"You answered {correct} questions out of " +
                $"{total} correctly, or {percentage}%.");
            Console.WriteLine(percentage > 75.0 ? "You know me pretty well!" :
                "You do not know me very well.");

            // Prompt the user to display the answer key (cheater cheater)
            Console.WriteLine("\nWould you like the answer key (y/N)?");

            if (Console.ReadLine().ToUpper().StartsWith("Y"))
            {
                foreach (Question question in questions)
                {
                    Console.WriteLine();
                    Console.WriteLine(question.ToString());
                }
            }

            // Ask the user to press a key before quitting
            Console.WriteLine();
            Console.WriteLine("Please press any key to exit...");
            Console.ReadKey();
        }
    }
}
