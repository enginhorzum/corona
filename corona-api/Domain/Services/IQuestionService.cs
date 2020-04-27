
using System.Collections.Generic;
using corona_api.Models;

namespace corona_api.Domain.Services
{
    public interface IQuestionService
    {
        List<Question> GetAllQuestions();
        Question GetQuestionById(string questionId);
        Question GetRootQuestion() ;
    }
}