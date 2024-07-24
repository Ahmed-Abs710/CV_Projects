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
    public class ExamController : ControllerBase
    {
        public IMediator Mediator { get; }

        public ExamController(IMediator mediator)
        {
            Mediator = mediator;
        }
        [HttpPost]
        [Route("CreateExam")]
        public async Task<IActionResult> CreateExam(ExamDto examDto)
        {
            var res =await Mediator.Send(new CreateExamCommand(examDto));
            if (res != null)
            {
                return Ok(res);
            }
            return BadRequest();
        }

        [HttpPut]
        [Route("UpdateExam")]
        public async Task<IActionResult> UpdateExam(int examid,UpdateExamDto examDto)
        {
            var res = await Mediator.Send(new UpdateExamCommand(examid,examDto));
            if (res != null)
            {
                return Ok(res);
            }
            return BadRequest();
        }

        [HttpDelete]
        [Route("DeleteExam")]
        public async Task<IActionResult> DeleteExam(int examid)
        {
            var res = await Mediator.Send(new DeleteExamCommand(examid));
               return Ok(res);
        }

        [HttpGet]
        [Route("GetExamById")]
        public async Task<IActionResult> GetExamById(int examid)
        {
            var res = await Mediator.Send(new GetExamByIdQuery(examid));
            if (res != null)
            {
                return Ok(res);
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("GetAllExams")]
        public async Task<IActionResult> GetAllExams()
        {
            var res = await Mediator.Send(new GetAllExamsQuery());
            if (res != null)
            {
                return Ok(res);
            }
            return BadRequest();
        }


        [HttpPost]
        [Route("SubmitAnswer")]
        public async Task<IActionResult> SubmitAnswer([FromBody] SubmitAnswerDto submitAnswerDto)
        {
            var res = await Mediator.Send(new SubmitAnswerCommand(submitAnswerDto));
            if (res != null)
            {
                return Ok(res);
            }
            return BadRequest();
        }

        //public async Task<IActionResult> CalculateResult([FromBody] CalculateResultDto submitAnswerDto)
        //{
        //    return Ok();
        //}


        [HttpPost]
        [Route("CreateExamResultAsync")]
        public async Task<IActionResult> CreateExamResultAsync([FromBody]CalculateResultDto calculateResultDto)
        {
            var res = await Mediator.Send(new  CreateExamResultCommand(calculateResultDto));
            if (res != null)
            {
                return Ok(res);
            }
            return BadRequest();
        }
    }
}
