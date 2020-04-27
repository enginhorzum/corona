using corona_api.Domain.Services;
using corona_api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace corona_api.Controllers
{
    [ApiController]
    public class AnswerController : ControllerBase
    {
        private readonly IAnswerService _answerService;

        public AnswerController(IAnswerService answerService)
        {
            _answerService = answerService;
        }

        [HttpPost]
        [Route("answer/save")]
        public ActionResult SaveAnswersList([FromBody]List<Answer> answersList)
        {
            _answerService.SaveAnswersList(answersList);
            return Ok(new ResponseModel{
                Status = true,
                Message = "Your message is delivered successfully."
            });
        }
        
    }
}