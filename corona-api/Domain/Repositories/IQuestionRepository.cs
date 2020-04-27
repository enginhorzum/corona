
using System.Collections.Generic;
using corona_api.Models;

namespace corona_api.Domain.Repositories
{
    public interface IQuestionRepository
    {
        List<Question> GetAllQuestions();
        Question GetQuestionById(string questionId);
        Question GetRootQuestion() ;
    }
}