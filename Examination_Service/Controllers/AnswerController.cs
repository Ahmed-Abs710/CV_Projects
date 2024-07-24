//using Examination_Service.Commands.Requests;
using Examination_Service.CQRS.Commands.Requests;
using Examination_Service.CQRS.Querys.Requests;
using Examination_Service.DTOs;
//using Examination_Service.Querys.Requests;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Examination_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        public IMediator Mediator { get; }

        public AnswerController(IMediator mediator)
        {
            Mediator = mediator;
        }

        [HttpPost]
        [Route("CreateAnswer")]
        public async Task<IActionResult> CreateAnswer(AnswerDto answerDto)
        {
            var res = await Mediator.Send(new CreateAnswerCommand(answerDto));
            if (res != null)
            {
                return Ok(res);
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("GetAnswerById")]
        public async Task<IActionResult> GetAnswerById(int AnswerId)
        {
            var res = await Mediator.Send(new GetAnswerByIdQuery(AnswerId));
            if (res != null)
            {
                return Ok(res);
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("GetAllAnswersByQuestionId")]
        public async Task<IActionResult> GetAllAnswersByQuestionId(int questionid)
        {
            var res = await Mediator.Send(new GetAllAnswersByQuestionIdQuery(questionid));
            if (res != null)
            {
                return Ok(res);
            }
            return BadRequest();
        }

        [HttpPut]
        [Route("UpdateAnswer")]
        public async Task<IActionResult> UpdateAnswer(int answerid,UpdateAnswerDto answerDto)
        {
            var res = await Mediator.Send(new UpdateAnswerCommand(answerid,answerDto));
            if (res != null)
            {
                return Ok(res);
            }
            return BadRequest();
        }

        [HttpDelete]
        [Route("DeleteAnswer")]
        public async Task<IActionResult> DeleteAnswer(int AnswerId)
        {
            var res = await Mediator.Send(new DeleteAnswerCommand(AnswerId));
            return Ok(res);
        }
    }
}
