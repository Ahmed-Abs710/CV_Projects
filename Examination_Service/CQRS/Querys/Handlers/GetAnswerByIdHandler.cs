using Examination_Service.CQRS.Querys.Requests;
using Examination_Service.Models;
using Examination_Service.Services;
using MediatR;

namespace Examination_Service.CQRS.Querys.Handlers
{
    public class GetAnswerByIdHandler : IRequestHandler<GetAnswerByIdQuery, Answer>
    {
        public GetAnswerByIdHandler(AnswerService answerService)
        {
            AnswerService = answerService;
        }

        public AnswerService AnswerService { get; }

        public async Task<Answer> Handle(GetAnswerByIdQuery request, CancellationToken cancellationToken)
        {
            return await AnswerService.GetAnswerByIdAsync(request.AnswerId);
        }
    }
}
