using System;
using System.Collections.Generic;
using WordCountFinder.Services;

namespace WordCountFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*************Word Counter Finder Starts*************");
            Console.WriteLine("\n\r");
            var inputRequest = new List<string[]>();

            // GetCommandlineInput(inputRequest);
            // Static input list

            inputRequest.Add(new string[] { "bird", "cat", "bird", "dog", "bird", "man", "frog", "cat" });
            inputRequest.Add(new string[] { "apple","vj", "tesasdt" });
            inputRequest.Add(new string[] { "jkj","vasdsadj", "jkjsd" });

            var wordCountResponse = new WordCountService().Calculate(inputRequest);
            Console.WriteLine("*************Input*************");
            Console.WriteLine("\n\r");
            foreach (var item in inputRequest)
            {
                Console.WriteLine(string.Join(',', item));
            }

            Console.WriteLine("\n\r");
            Console.WriteLine("*************Result*************");
            Console.WriteLine("\n\r");

            if (wordCountResponse != null && wordCountResponse.Result != null &&
                wordCountResponse.Result.ResultStatus != Enums.ResultStatus.Success)
            {
                Console.WriteLine($"Unable to calculate the count - {wordCountResponse.Result.ErrorMessage}");
            }
            else
            {
                string wordsInMoreThanOneList;
                var response = wordCountResponse.WordCountModel;
                if (response.WordsInMoreThanOneList != null && response.WordsInMoreThanOneList.Length > 0)
                {
                    wordsInMoreThanOneList = string.Join(",", response.WordsInMoreThanOneList);
                }
                else
                {
                    wordsInMoreThanOneList = "N/A";
                }
                Console.WriteLine($"Words in more than one List : {wordsInMoreThanOneList}");
                Console.WriteLine($"Number of unique word in all list: {response.NumberOfUniqueWordsInAllList}");


                string topFiveFrequestWordsInAllList;
                if (response.TopFiveFrequestWordsInAllList != null && response.TopFiveFrequestWordsInAllList.Length > 0)
                {
                    topFiveFrequestWordsInAllList = string.Join(",", response.TopFiveFrequestWordsInAllList);
                }
                else
                {
                    topFiveFrequestWordsInAllList = "N/A";
                }
                Console.WriteLine($"Top five frequent words in all List :{topFiveFrequestWordsInAllList}");
                Console.WriteLine("\n\r");
            }
            Console.WriteLine("*************Word Counter Finder Ends*************");
            Console.WriteLine("\n\r\n\r\n\r\n\r");
        }

        private static void GetCommandlineInput(List<string[]> inputRequest)
        {
            do
            {
                Console.WriteLine("Enter a List of strings as comma separated values");
                var input = Console.ReadLine();
                inputRequest.Add(input.Split(','));
                Console.WriteLine("Enter q quit and show the result or space bar to type another list");
            } while (Console.ReadKey(true).Key != ConsoleKey.Q);
        }
    }
}
