using Examination_Service.CQRS.Querys.Requests;
using Examination_Service.Models;
using Examination_Service.Services;
using MediatR;

namespace Examination_Service.CQRS.Querys.Handlers
{
    public class GetAllAnswersByQuestionIdHandler : IRequestHandler<GetAllAnswersByQuestionIdQuery, IEnumerable<Answer>>
    {
        public GetAllAnswersByQuestionIdHandler(AnswerService answerService)
        {
            AnswerService = answerService;
        }

        public AnswerService AnswerService { get; }

        public Task<IEnumerable<Answer>> Handle(GetAllAnswersByQuestionIdQuery request, CancellationToken cancellationToken)
        {
            return AnswerService.GetAllAnswersByQuestionIdAsync(request.QuestionId);
        }
    }
}
