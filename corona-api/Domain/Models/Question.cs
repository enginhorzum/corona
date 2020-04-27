using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace corona_api.Models
{
    [BsonIgnoreExtraElements]
    public class Question
    {
         public string questionId { get; set; }

        public string questionText { get; set; }

        public string yesQuestionId { get; set; }

        public string noQuestionId { get; set; }
    }
}