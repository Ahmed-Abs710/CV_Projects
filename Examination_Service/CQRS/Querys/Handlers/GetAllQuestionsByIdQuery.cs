using Examination_Service.CQRS.Querys.Requests;
using Examination_Service.Models;
using Examination_Service.Services;
using MediatR;

namespace Examination_Service.CQRS.Querys.Handlers
{
    public class GetAllQuestionsByIdQuery : IRequestHandler<GetQuestionByIdQuery, Question>
    {
        public GetAllQuestionsByIdQuery(QuestionService questionService)
        {
            QuestionService = questionService;
        }

        public QuestionService QuestionService { get; }

        public Task<Question> Handle(GetQuestionByIdQuery request, CancellationToken cancellationToken)
        {
            return QuestionService.GetQuestionByIdAsync(request.QuestionId);
        }
    }
}
