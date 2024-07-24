using Examination_Service.CQRS.Commands.Requests;
using Examination_Service.Models;
using Examination_Service.Services;
using MediatR;

namespace Examination_Service.CQRS.Commands.Handlers
{
    public class CreateQuestionHandler : IRequestHandler<CreateQuestionCommand, Question>
    {
        public CreateQuestionHandler(QuestionService questionService)
        {
            QuestionService = questionService;
        }

        public QuestionService QuestionService { get; }

        public async Task<Question> Handle(CreateQuestionCommand request, CancellationToken cancellationToken)
        {
            return await QuestionService.CreateQuestionAsync(request.questionDto);
        }
    }
}
