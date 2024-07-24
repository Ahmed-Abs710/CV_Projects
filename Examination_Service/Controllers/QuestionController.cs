//using Examination_Service.Commands.Requests;
using Examination_Service.DTOs;
//using Examination_Service.Querys.Requests;
using Examination_Service.CQRS.Commands.Requests;
using Examination_Service.CQRS.Querys.Requests;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Examination_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        public IMediator Mediator { get; }

        public QuestionController(IMediator mediator)
        {
            Mediator = mediator;
        }

        [HttpPost]
        [Route("CreateQuestion")]
        public async Task<IActionResult> CreateQuestion(QuestionDto questionDto)
        {
            var res = await Mediator.Send(new CreateQuestionCommand(questionDto));
            if (res != null)
            {
                return Ok(res);
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("GetQuestionById")]
        public async Task<IActionResult> GetQuestionById(int QuestionId)
        {
            var res = await Mediator.Send(new GetQuestionByIdQuery(QuestionId));
            if (res != null)
            {
                return Ok(res);
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("GeAlltQuestions")]
        public async Task<IActionResult> GeAlltQuestions()
        {
            var res = await Mediator.Send(new GetAllQuestionsQuery());
            if (res != null)
            {
                return Ok(res);
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("GetAllQuestionsByExamId")]
        public async Task<IActionResult> GetAllQuestionsByExamId(int examid)
        {
            var res = await Mediator.Send(new GetAllQuestionsByExamIdQuery(examid));
            if (res != null)
            {
                return Ok(res);
            }
            return BadRequest();
        }

        [HttpPut]
        [Route("UpdateQuestion")]
        public async Task<IActionResult> UpdateQuestion(int questionid ,UpdateQuestionDto questionDto)
        {
            var res = await Mediator.Send(new UpdateQuestionCommand(questionid,questionDto));
            if (res != null)
            {
                return Ok(res);
            }
            return BadRequest();
        }

        [HttpDelete]
        [Route("DeleteQuestion")]
        public async Task<IActionResult> DeleteQuestion(int QuestionId)
        {
            var res = await Mediator.Send(new DeleteQuestionCommand(QuestionId));
            return Ok(res);
        }

    }
}
