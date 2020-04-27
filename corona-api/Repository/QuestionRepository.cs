using System.Collections.Generic;
using corona_api.Domain.Repositories;
using corona_api.Models;
using MongoDB.Driver;

namespace corona_api.Repository
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly IMongoCollection<Question> _questionsCollection;
        public QuestionRepository(IQuestionDatabaseSettings settings)        
        {         
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _questionsCollection = database.GetCollection<Question>(settings.QuestionsCollectionName);
        }

        public List<Question> GetAllQuestions() =>
            _questionsCollection.Find(q => true).ToList();

        public Question GetQuestionById(string questionId) =>
            _questionsCollection.Find<Question>(q => q.questionId == questionId).FirstOrDefault();  

        public Question GetRootQuestion() =>
            _questionsCollection.Find<Question>(q => q.questionId == "root").FirstOrDefault();    
    }
}