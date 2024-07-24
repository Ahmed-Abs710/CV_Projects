using Examination_Service.CQRS.Commands.Requests;
using Examination_Service.Services;
using MediatR;

namespace Examination_Service.CQRS.Commands.Handlers
{
    public class DeleteQuestionHandler : IRequestHandler<DeleteQuestionCommand, bool>
    {
        public DeleteQuestionHandler(QuestionService questionService)
        {
            QuestionService = questionService;
        }

        public QuestionService QuestionService { get; }

        public async Task<bool> Handle(DeleteQuestionCommand request, CancellationToken cancellationToken)
        {
            return await QuestionService.DeleteQuestionAsync(request.QuestionId);
        }
    }
}
