using Examination_Service.CQRS.Commands.Requests;
using Examination_Service.Services;
using MediatR;

namespace Examination_Service.CQRS.Commands.Handlers
{
    public class DeleteAnswerHandler : IRequestHandler<DeleteAnswerCommand, bool>
    {
        public DeleteAnswerHandler(AnswerService answerService)
        {
            AnswerService = answerService;
        }

        public AnswerService AnswerService { get; }

        public async Task<bool> Handle(DeleteAnswerCommand request, CancellationToken cancellationToken)
        {
            return await AnswerService.DeleteAnswerAsync(request.AnswerId);
        }
    }
}
