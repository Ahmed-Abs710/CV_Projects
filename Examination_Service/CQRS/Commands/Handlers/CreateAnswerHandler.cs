using Examination_Service.CQRS.Commands.Requests;
using Examination_Service.Models;
using Examination_Service.Services;
using MediatR;

namespace Examination_Service.CQRS.Commands.Handlers
{
    public class CreateAnswerHandler : IRequestHandler<CreateAnswerCommand, Answer>
    {
        public CreateAnswerHandler(AnswerService answerService)
        {
            AnswerService = answerService;
        }

        public AnswerService AnswerService { get; }

        public async Task<Answer> Handle(CreateAnswerCommand request, CancellationToken cancellationToken)
        {
            return await AnswerService.CreateAnswerAsync(request.answerDto);
        }
    }
}
