using System;
using System.Collections.Generic;
using System.Linq;
using WordCountFinder.Response;

namespace WordCountFinder.Services
{
    public class WordCountService : IWordCountService
    {
        /// <inheritdoc />
        public WordCountResponse Calculate(List<string[]> inputRequest)
        {
            var wordsInMoreThanOneList = new List<string>();
            var uniqueWordsInAllList = new Dictionary<string, int>();
            var frequentWordsInAllList = new Dictionary<string, int>();

            // Return empty if input request is null or empty.
            if (inputRequest == null || !inputRequest.Any())
            {
                return new WordCountResponse(new Result(Enums.ResultStatus.Fail, "Input list can't be empty"));
            }
            try
            {
                for (int currentRow = 0; currentRow < inputRequest.Count; currentRow++)
                {
                    var currentColumn = 0;

                    while (currentColumn < inputRequest[currentRow].Length)
                    {
                        var currentColumnData = inputRequest[currentRow][currentColumn];

                        // Frequest words in all list 
                        FindFrequentWordInAllList(inputRequest, frequentWordsInAllList, currentRow, currentColumn, currentColumnData);

                        // Find unique word in all List Logic 
                        FindUniqueWordInAllList(uniqueWordsInAllList, currentColumnData);

                        // Words in More Than One List Logic  
                        if (wordsInMoreThanOneList.Contains(currentColumnData))
                        {
                            currentColumn++;
                            continue;
                        }
                        FindWordsInMoreThanOneList(inputRequest, wordsInMoreThanOneList, currentRow, currentColumnData);

                        currentColumn++;
                    }
                }

                var topFiveFrequentWords = frequentWordsInAllList.Where(x => x.Value > 0).OrderByDescending(x => x.Value).Take(5).Select(x => x.Key);
                var uniqueWordsInAllListCount = uniqueWordsInAllList.Where(x => x.Value == 0).Count();
                return new WordCountResponse
                {
                    WordCountModel = new WordCountModel(wordsInMoreThanOneList.ToArray(), uniqueWordsInAllListCount, topFiveFrequentWords.ToArray())
                };
            }
            catch (Exception ex)
            {
                return new WordCountResponse(new Result(Enums.ResultStatus.Error, "Unexpected error occurred on word search count", "0001"));
            }
        }

        /// <summary>
        /// Words in More Than One List Logic  
        /// </summary>
        /// <param name="inputRequest"></param>
        /// <param name="wordsInMoreThanOneList"></param>
        /// <param name="currentRow"></param>
        /// <param name="currentColumnData"></param>
        private static void FindWordsInMoreThanOneList(List<string[]> inputRequest, List<string> wordsInMoreThanOneList, int currentRow, string currentColumnData)
        {
            var isWordInMoreThanOneListFound = false;
            if ((currentRow + 1) < inputRequest.Count)
            {
                var nextRow = currentRow + 1;
                while (nextRow < inputRequest.Count)
                {
                    foreach (var nextColumnData in inputRequest[nextRow])
                    {
                        if (isWordInMoreThanOneListFound)
                        { break; }
                        if (string.Equals(currentColumnData, nextColumnData, StringComparison.OrdinalIgnoreCase))
                        {
                            wordsInMoreThanOneList.Add(currentColumnData);
                            isWordInMoreThanOneListFound = true;
                        }

                    }
                    nextRow++;
                }
            }
        }

        /// <summary>
        /// Find unique word in all List Logic 
        /// </summary>
        /// <param name="uniqueWordsInAllList"></param>
        /// <param name="currentColumnData"></param>
        private static void FindUniqueWordInAllList(Dictionary<string, int> uniqueWordsInAllList, string currentColumnData)
        {
            if (!uniqueWordsInAllList.ContainsKey(currentColumnData))
            {
                uniqueWordsInAllList.Add(currentColumnData, 0);
            }
            else
            {
                uniqueWordsInAllList[currentColumnData] = uniqueWordsInAllList[currentColumnData] + 1;
            }
        }

        /// <summary>
        /// Get all Frequent words in all list 
        /// </summary>
        /// <param name="inputRequest"></param>
        /// <param name="frequentWordsInAllList"></param>
        /// <param name="currentRow"></param>
        /// <param name="currentColumn"></param>
        /// <param name="currentColumnData"></param>
        /// <returns></returns>
        private static string FindFrequentWordInAllList(List<string[]> inputRequest, Dictionary<string, int> frequentWordsInAllList, int currentRow,
            int currentColumn, string currentColumnData)
        {

            if (!frequentWordsInAllList.ContainsKey(currentColumnData))
            {
                frequentWordsInAllList.Add(currentColumnData, 0);
            }


            var currentColumnForFrequentWordsInAllList = currentColumn + 1;
            while (currentColumnForFrequentWordsInAllList < inputRequest[currentRow].Length)
            {
                var nextColumnDataInSameRow = inputRequest[currentRow][currentColumnForFrequentWordsInAllList];
                if (string.Equals(currentColumnData, nextColumnDataInSameRow, StringComparison.OrdinalIgnoreCase))
                {
                    frequentWordsInAllList[currentColumnData] = frequentWordsInAllList[currentColumnData] + 1;
                }
                currentColumnForFrequentWordsInAllList++;
            }

            return currentColumnData;
        }
    }
}
