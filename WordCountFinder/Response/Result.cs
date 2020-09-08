using System;
using System.Collections.Generic;
using System.Text;
using WordCountFinder.Enums;

namespace WordCountFinder.Response
{
    /// <summary>
    /// Result
    /// </summary>
    public class Result
    {
        /// <summary>
        /// Status code
        /// </summary>
        public string StatusCode { get; set; }
        /// <summary>
        /// Error message
        /// </summary>
        public string ErrorMessage { get; set; }
        /// <summary>
        /// Result Status
        /// </summary>
        public ResultStatus ResultStatus { get; set; }

        /// <summary>
        /// Result
        /// </summary>
        /// <param name="resultStatus"></param>
        /// <param name="errorMessage"></param>
        /// <param name="statusCode"></param>
        public Result(ResultStatus resultStatus = ResultStatus.Success, string errorMessage = null, string statusCode =null)
        {
            StatusCode = statusCode;
            ResultStatus = resultStatus;
            ErrorMessage = errorMessage;
        }
    }
}
