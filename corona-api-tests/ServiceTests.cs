using System;
using System.Linq;
using AutoFixture;
using FakeItEasy;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;
using FluentAssertions;
using Xunit;
using corona_api.Services;
using corona_api.Models;
using System.Collections.Generic;
using corona_api.Domain.Repositories;

namespace corona_api_tests
{
    public class ServiceTests
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly Fixture _fixture;        
        private readonly QuestionService _questionService;

        public ServiceTests()
        {
            _questionRepository = A.Fake<IQuestionRepository>();
            _fixture = new Fixture();
            _questionService = new QuestionService(_questionRepository);
        }        

        [Fact]
        public void GetAllQuestions_Should_Success()
        {
            //Arrange
            var questions = _fixture.CreateMany<Question>(3).ToList();
            A.CallTo(() => _questionRepository.GetAllQuestions()).Returns(questions);
            
            //Act
            var result = _questionService.GetAllQuestions();
        
            //Assert
            Assert.Equal(questions.Count(), result.Count);
        }        
    }
}