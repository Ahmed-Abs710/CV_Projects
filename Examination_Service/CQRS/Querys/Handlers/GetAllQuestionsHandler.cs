using Examination_Service.CQRS.Querys.Requests;
using Examination_Service.Models;
using Examination_Service.Services;
using MediatR;

namespace Examination_Service.CQRS.Querys.Handlers
{
    public class GetAllQuestionsHandler : IRequestHandler<GetAllQuestionsByExamIdQuery, IEnumerable<Question>>
    {
        public GetAllQuestionsHandler(QuestionService questionService)
        {
            QuestionService = questionService;
        }

        public QuestionService QuestionService { get; }

        public Task<IEnumerable<Question>> Handle(GetAllQuestionsByExamIdQuery request, CancellationToken cancellationToken)
        {
            return QuestionService.GetAllQuestionsByExamIdAsync(request.examid);
        }
    }
}
