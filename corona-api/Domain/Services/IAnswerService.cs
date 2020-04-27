
using System.Collections.Generic;
using corona_api.Models;

namespace corona_api.Domain.Services
{
    public interface IAnswerService
    {
        void SaveAnswersList(List<Answer> answersList);
    }
}