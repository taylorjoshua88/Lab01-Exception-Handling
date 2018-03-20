using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;

namespace AboutMeQuiz
{
    /// <summary>
    /// Represents a single question in the About Me quiz.
    /// </summary>
    [DataContract]
    public struct Question
    {
        /// <summary>
        /// The prompt text that is presented when the question is asked
        /// </summary>
        [DataMember]
        public string Prompt { get; set; }

        /// <summary>
        /// The answer in string format
        /// </summary>
        [DataMember]
        public string AnswerString { get; set; }

        /// <summary>
        /// The Answer in integral format
        /// </summary>
        [DataMember]
        public int? AnswerInt { get; set; }

        /// <summary>
        /// This question has a string answer provided
        /// </summary>
        public bool HasStringAnswer { get => !(AnswerString is null); }
        /// <summary>
        /// This question has an integral answer provided
        /// </summary>
        public bool HasIntAnswer { get => AnswerInt.HasValue; }

        /// <summary>
        /// Loads a single Question object from a JSON file
        /// </summary>
        /// <param name="jsonPath">Local path to a JSON file</param>
        /// <returns>A new Question object deserialized from JSON</returns>
        public static Question FromJSON(string jsonPath)
        {
            DataContractJsonSerializer QuestionSerializer = new 
                DataContractJsonSerializer(typeof(Question));
            StreamReader jsonFileReader = new StreamReader(jsonPath);
            Question newQuestion;

            // Try to deserialize the QuestionList, ensuring that the
            // file is closed and any exceptions are logged to the console
            try
            {
                newQuestion = (Question)QuestionSerializer.
                    ReadObject(jsonFileReader.BaseStream);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            finally
            {
                jsonFileReader.Close();
            }

            return newQuestion;
        }

        /// <summary>
        /// Prompt the user for the answer to the question via the console
        /// and blocks for user input.
        /// </summary>
        /// <returns>True for correct answers; false for incorrect answers</returns>
        public bool AskConsole()
        {
            // Display the prompt. If it wasn't provided in JSON or in C#
            // then display an embarrassing fallback string
            Console.WriteLine(Prompt ?? "No prompt provided for this " +
                "question. Please press enter...");

            // Receive the user's response
            string response = Console.ReadLine();

            // If this question has a string answer and it matches input
            // then return true
            if (HasStringAnswer && response.ToUpper() == AnswerString.ToUpper())
            {
                return true;
            }

            try
            {
            // If this question has an integral answer and it matches user input
            // then return true
                if (HasIntAnswer && Convert.ToInt32(response) == AnswerInt)
                {
                    return true;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("I could not understand your answer.");
                Console.WriteLine("Please provide a numeric answer without any decimal points.");
                Console.WriteLine("For example: 20 rather than twenty or 20.0");
                Console.WriteLine();

                // Recursively ask for the answer until a proper answer is provided
                return AskConsole();
            }
            catch (OverflowException)
            {
                Console.WriteLine("Please provide a numeric answer between" +
                    $" {int.MinValue} and {int.MaxValue}.");
                Console.WriteLine();

                // Recursively ask for the answer until a proper answer is provided
                return AskConsole();
            }

            // The answer was wrong
            return false;
        }

        /// <summary>
        /// Outputs a string containing the question's prompt and answer
        /// </summary>
        /// <returns>String containing the question's prompt and answer</returns>
        public override string ToString()
        {
            if (HasStringAnswer)
            {
                return Prompt + $"\nAnswer: {AnswerString}";
            }
            if (HasIntAnswer)
            {
                return Prompt + $"\nAnswer: {AnswerInt}";
            }

            return Prompt + "\nNo answer found!";
        }
    }
}
