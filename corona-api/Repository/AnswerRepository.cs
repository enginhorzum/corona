using System;
using System.Collections.Generic;
using corona_api.Domain.Repositories;
using corona_api.Models;
using MongoDB.Driver;

namespace corona_api.Repository
{
    public class AnswerRepository : IAnswerRepository
    {
        private readonly IMongoCollection<AnswersList> _answersCollection;
        public AnswerRepository(IQuestionDatabaseSettings settings)        
        {         
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _answersCollection = database.GetCollection<AnswersList>(settings.AnswersCollectionName);
        }

        public void SaveAnswersList(List<Answer> answersList)
        {
            _answersCollection.InsertOne(new AnswersList { answersList = answersList, timeStamp = DateTime.UtcNow });
        }
    }
}