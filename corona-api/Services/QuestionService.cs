
using corona_api.Domain.Repositories;
using corona_api.Domain.Services;
using corona_api.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace corona_api.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;
        public QuestionService(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public List<Question> GetAllQuestions()
        {
            return _questionRepository.GetAllQuestions();
        }

        public Question GetQuestionById(string questionId)
        {
            return _questionRepository.GetQuestionById(questionId);
        }

        public Question GetRootQuestion()
        {
            return _questionRepository.GetRootQuestion();
        }
    }
}