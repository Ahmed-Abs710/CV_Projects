using Examination_Service.CQRS.Commands.Requests;
using Examination_Service.Models;
using Examination_Service.Services;
using MediatR;

namespace Examination_Service.CQRS.Commands.Handlers
{
    public class UpdateAnswerHandler : IRequestHandler<UpdateAnswerCommand, Answer>
    {
        public UpdateAnswerHandler(AnswerService answerService)
        {
            AnswerService = answerService;
        }

        public AnswerService AnswerService { get; }

        public async Task<Answer> Handle(UpdateAnswerCommand request, CancellationToken cancellationToken)
        {
            return await AnswerService.UpdateAnswerAsync(request.answerid, request.updateAnswerDto);
        }
    }
}
