using System;
using System.Collections.Generic;
using System.Text;

namespace WordCountFinder.Response
{
    /// <summary>
    /// Word count model
    /// </summary>
    public class WordCountModel
    {
        /// <summary>
        /// Words in more than one list
        /// </summary>
        public string[] WordsInMoreThanOneList { get; set; }

        /// <summary>
        /// Number of unique words in all list
        /// </summary>
        public int NumberOfUniqueWordsInAllList { get; set; } 

        /// <summary>
        /// Top five frequnt words in all list
        /// </summary>
        public string[] TopFiveFrequestWordsInAllList { get; set; }

        public WordCountModel(string[] wordsInMoreThanOneList, int numberOfUniqueWordsInAllList, string[] topFiveFrequestWordsInAllList)
        {
            WordsInMoreThanOneList = wordsInMoreThanOneList;
            NumberOfUniqueWordsInAllList = numberOfUniqueWordsInAllList;
            TopFiveFrequestWordsInAllList = topFiveFrequestWordsInAllList;
        }
        public WordCountModel()
        {

        }
    }
}
