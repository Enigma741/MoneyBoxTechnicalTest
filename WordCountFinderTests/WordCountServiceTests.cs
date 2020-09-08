using System;
using System.Collections.Generic;
using WordCountFinder.Enums;
using WordCountFinder.Services;
using Xunit;

namespace WordCountFinderTests
{
    public class WordCountServiceTests
    {
        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void Calulate_When_InputList_Is_Null_Or_Empty_Return_ErrorMessage(bool isInputRequestEmpty)
        {
            // Arrange
            var service = new WordCountService();

            // Act
            var response = service.Calculate(isInputRequestEmpty ? null : new List<string[]>());

            //Assert
            Assert.NotNull(response);
            Assert.NotNull(response.Result);
            Assert.Equal(ResultStatus.Fail, response.Result.ResultStatus );
            Assert.Equal("Input list cannt be empty", response.Result.ErrorMessage);
        }

        [Theory]
        [InlineData("Apple,Orange,Test/Apple,Test/Pears,Grapes,Test,Apple", "Apple,Test")]
        [InlineData("Apple,Orange,Test/Pears,Grapes/Apple", "Apple")]
        [InlineData("A,B,C,D/E,F,G/H,K,I/C,M,G" ,"C,G")]
       
        public void Calulate_When_Input_Has_ValidData_Calculate_WordsInMoreThanOneList(string inputRequest,string expectedResponse)
        {
            // Arrange
            var service = new WordCountService();
            var inputRequestArray = inputRequest.Split("/");
            var inputListOfList = new List<string[]>();
            foreach (var item in inputRequestArray)
            {
                var splitedData = item.Split(",");
                inputListOfList.Add(splitedData);
            }

            // Act
            var response = service.Calculate(inputListOfList);

            //Assert
            Assert.NotNull(response);
            Assert.NotNull(response.Result);
            Assert.NotNull(response.WordCountModel);
            Assert.Equal(ResultStatus.Success, response.Result.ResultStatus);
            Assert.NotNull(response.WordCountModel.WordsInMoreThanOneList);
            Assert.Equal(string.Join(",",response.WordCountModel.WordsInMoreThanOneList), expectedResponse);
        }

        [Theory] 
        [InlineData("A,B,C,D/E,A,D,K,I/C,M,G", 6)]
        [InlineData("Apple,Bird,Chips/Chips,Coke/Apple", 2)]
        [InlineData("A,B,C,D/E,F,G/H,K,I/C,M,G", 9)] 
        public void Calulate_When_Input_Has_ValidData_Calculate_UniqueWordsInAllList(string inputRequest, int expectedResponse)
        {
            // Arrange
            var service = new WordCountService();
            var inputRequestArray = inputRequest.Split("/");
            var inputListOfList = new List<string[]>();
            foreach (var item in inputRequestArray)
            {
                var splitedData = item.Split(",");
                inputListOfList.Add(splitedData);
            }

            // Act
            var response = service.Calculate(inputListOfList);

            //Assert
            Assert.NotNull(response);
            Assert.NotNull(response.Result);
            Assert.NotNull(response.WordCountModel);
            Assert.Equal(ResultStatus.Success, response.Result.ResultStatus);
            Assert.Equal(response.WordCountModel.NumberOfUniqueWordsInAllList, expectedResponse); 
        }


        [Theory]
        [InlineData("A,B,A,D,A/E,A,I,D,I,K,I/C,M,G,C/M,J,M/L,L,L/O,P,P", "A,I,L,C,M")]
        [InlineData("Apple,Bird,Chips,Bird/Chips,Coke/Apple", "Bird")]
        [InlineData("A,B,C,D/E,F,G/H,I,K,I/C,M,G", "I")]
        [InlineData("A,B,C,D/E,F,G/H,I,K/C,M,G", "")]
        public void Calulate_When_Input_Has_ValidData_Calculate_TopFiveFrequestWordsInAllList(string inputRequest, string expectedResponse)
        {
            // Arrange
            var service = new WordCountService();
            var inputRequestArray = inputRequest.Split("/");
            var inputListOfList = new List<string[]>();
            foreach (var item in inputRequestArray)
            {
                var splitedData = item.Split(",");
                inputListOfList.Add(splitedData);
            }

            // Act
            var response = service.Calculate(inputListOfList);

            //Assert
            Assert.NotNull(response);
            Assert.NotNull(response.Result);
            Assert.NotNull(response.WordCountModel);
            Assert.Equal(ResultStatus.Success, response.Result.ResultStatus);
            Assert.Equal(string.Join(",", response.WordCountModel.TopFiveFrequestWordsInAllList), expectedResponse);
        }
    }
}
