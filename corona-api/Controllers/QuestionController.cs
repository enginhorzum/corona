using corona_api.Domain.Services;
using corona_api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace corona_api.Controllers
{
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;

        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpGet]
        [Route("question/all")]
        public ActionResult<List<Question>> Get() =>
            _questionService.GetAllQuestions();


        [HttpGet]
        [Route("question/{questionId}")]
        public ActionResult<Question> GetQuestion(string questionId)
        {
            var question = _questionService.GetQuestionById(questionId);

            if (question == null)
            {
                return NotFound();
            }

            return question;
        }

        [HttpGet]
        [Route("question/root")]
        public ActionResult<Question> GetRootQuestion()
        {
            var question = _questionService.GetRootQuestion();

            if (question == null)
            {
                return NotFound();
            }

            return question;
        }
        
    }
}