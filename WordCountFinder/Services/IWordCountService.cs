using System;
using System.Collections.Generic;
using System.Text;
using WordCountFinder.Response;

namespace WordCountFinder.Services
{
    public interface IWordCountService
    {
        /// <summary>
        /// Calculate word counts
        /// </summary>
        /// <param name="inputRequest"></param>
        /// <returns></returns>
        WordCountResponse Calculate(List<string[]> inputRequest);
    }
}
