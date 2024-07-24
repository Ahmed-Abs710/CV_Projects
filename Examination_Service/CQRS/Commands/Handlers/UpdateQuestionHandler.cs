using Examination_Service.CQRS.Commands.Requests;
using Examination_Service.Models;
using Examination_Service.Services;
using MediatR;

namespace Examination_Service.CQRS.Commands.Handlers
{
    public class UpdateQuestionHandler : IRequestHandler<UpdateQuestionCommand, Question>
    {
        public UpdateQuestionHandler(QuestionService questionService)
        {
            QuestionService = questionService;
        }

        public QuestionService QuestionService { get; }

        public async Task<Question> Handle(UpdateQuestionCommand request, CancellationToken cancellationToken)
        {
            return await QuestionService.UpdateQuestionAsync(request.questionid, request.updateQuestionDto);
        }
    }
}
