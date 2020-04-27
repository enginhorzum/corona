using System;
using System.Linq;
using FluentAssertions;
using Xunit;
using corona_api.Repository;
using corona_api.Models;
using Moq;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using FakeItEasy;
using AutoFixture;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace corona_api_tests
{
    public class RepositoryTests
    {
        // private readonly IQuestionDatabaseSettings _settings;
        // private readonly Fixture _fixture; 
        private Mock<IQuestionDatabaseSettings> _mockOptions;

        private Mock<IMongoDatabase> _mockDB;

        private Mock<IMongoClient> _mockClient;

        public RepositoryTests()
        {
            // _settings = A.Fake<IQuestionDatabaseSettings>();
            // _fixture = new Fixture();
            _mockOptions = new Mock<IQuestionDatabaseSettings>();
            _mockDB = new Mock<IMongoDatabase>();
            _mockClient = new Mock<IMongoClient>();
        }
        
        [Fact]
        public void Get_RootQuestion_Should_Success()
        {
            var question = new Question { questionId = "root", questionText = "Do you have fever?", yesQuestionId = "cough", noQuestionId = "enjoy" };
            // var question2 = new Question { questionId = "cough", questionText = "Are you coughing?", yesQuestionId = "breath", noQuestionId = "paracetamol" };
            // var question3 = new Question { questionId = "paracetamol", questionText = "Get some paracetamol", yesQuestionId = null, noQuestionId = null };
            // var answer1 = new Answer { question = question1, yesOrNo = true, order = 1 };
            // var answer2 = new Answer { question = question2, yesOrNo = false, order = 2 };
            // var answer3 = new Answer { question = question3, yesOrNo = false, order = 3 };


            //Arrange
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false)
                .Build();

            var settings = Options.Create(configuration.GetSection(nameof(QuestionDatabaseSettings)).Get<QuestionDatabaseSettings>());

            //_mockOptions.Setup(s => s).Returns(settings);
            _mockClient.Setup(c => c.GetDatabase(settings.Value.DatabaseName, null)).Returns(_mockDB.Object);

            //Act 
            var questionRepository = new QuestionRepository(settings.Value);
            var rootQuestion = questionRepository.GetRootQuestion();

            //Assert 
            Assert.Equal("root", rootQuestion.questionId);
        }        
    }
}