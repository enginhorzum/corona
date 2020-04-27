using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace corona_api.Models
{
    [BsonIgnoreExtraElements]
    public class AnswersList
    {
        public List<Answer> answersList { get; set; }

        public DateTime timeStamp{ get; set; } = DateTime.UtcNow;
    }
}