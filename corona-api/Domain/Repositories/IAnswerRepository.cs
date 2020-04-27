
using System.Collections.Generic;
using corona_api.Models;

namespace corona_api.Domain.Repositories
{
    public interface IAnswerRepository
    {
        void SaveAnswersList(List<Answer> answersList);
    }
}