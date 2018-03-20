using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace AboutMeQuiz
{
    class QuestionList : List<Question>
    {
        /// <summary>
        /// Ask the user every question within the collection
        /// </summary>
        /// <returns>Value tuple containing the number of correct
        /// answers and total number of questions as integers</returns>
        public (int correct, int total) AskConsoleAll()
        {
            int correctAnswers = 0;

            foreach (Question question in this)
            {
                // If the question is answered correctly, then increase
                // the correct answer tally
                correctAnswers += question.AskConsole() ? 1 : 0;
                // Add an extra newline to clean up output
                Console.WriteLine();
            }

            return (correctAnswers, this.Count);
        }

        /// <summary>
        /// Deserializes a JSON array of Question objects
        /// </summary>
        /// <param name="jsonPath">Path to the JSON file</param>
        /// <returns>A new QuestionList containing Question objects
        /// deserialized from the provided JSON file.</returns>
        public static QuestionList FromJSON(string jsonPath)
        {
            DataContractJsonSerializer QuestionSerializer = new 
                DataContractJsonSerializer(typeof(QuestionList));
            StreamReader jsonFileReader = new StreamReader(jsonPath);
            QuestionList newQuestionList;

            // Try to deserialize the QuestionList, ensuring that the
            // file is closed and any exceptions are logged to the console
            try
            {
                newQuestionList = (QuestionList)QuestionSerializer.
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

            return newQuestionList;
        }

    }
}
