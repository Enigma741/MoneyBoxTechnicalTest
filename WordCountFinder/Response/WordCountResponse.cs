using System;
using System.Collections.Generic;
using System.Text;

namespace WordCountFinder.Response
{
    /// <summary>
    /// Word Count response
    /// </summary>
    public class WordCountResponse
    {
        /// <summary>
        /// Result
        /// </summary>
        public Result Result { get; set; }

        /// <summary>
        /// Word count details
        /// </summary>
        public WordCountModel WordCountModel { get; set; }

        /// <summary>
        /// Word count response
        /// </summary>
        /// <param name="result"></param>
        /// <param name="wordCountModel"></param>
        public WordCountResponse(Result result, WordCountModel wordCountModel)
        {
            Result = result;
            WordCountModel = wordCountModel;
        }

        /// <summary>
        /// Word count response
        /// </summary>
        /// <param name="result"></param>
        public WordCountResponse(Result result)
        {
            Result = result;
            WordCountModel = new WordCountModel();
        }
        public WordCountResponse()
        {
            Result = new Result();
        }
    }
}
