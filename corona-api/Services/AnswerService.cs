
using corona_api.Domain.Repositories;
using corona_api.Domain.Services;
using corona_api.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace corona_api.Services
{
    public class AnswerService: IAnswerService
    {
        private readonly IAnswerRepository _answerRepository;

        public AnswerService(IAnswerRepository answerRepository)
        {
            _answerRepository = answerRepository;
        }

        public void SaveAnswersList(List<Answer> answersList)
        {
            _answerRepository.SaveAnswersList(answersList);
        }
  
    }
}