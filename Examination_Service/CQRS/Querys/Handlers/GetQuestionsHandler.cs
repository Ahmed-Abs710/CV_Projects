using Examination_Service.CQRS.Querys.Requests;
using Examination_Service.Models;
using Examination_Service.Services;
using MediatR;

namespace Examination_Service.CQRS.Querys.Handlers
{
    public class GetQuestionsHandler : IRequestHandler<GetAllQuestionsQuery, IEnumerable<Question>>
    {
        public GetQuestionsHandler(QuestionService questionService)
        {
            QuestionService = questionService;
        }

        public QuestionService QuestionService { get; }

        Task<IEnumerable<Question>> IRequestHandler<GetAllQuestionsQuery, IEnumerable<Question>>.Handle(GetAllQuestionsQuery request, CancellationToken cancellationToken)
        {
            return QuestionService.GetAllQuestionsAsync();
        }
    }
}
