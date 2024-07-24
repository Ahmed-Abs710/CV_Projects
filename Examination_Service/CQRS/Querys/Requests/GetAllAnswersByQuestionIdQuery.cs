using Examination_Service.Models;
using MediatR;

namespace Examination_Service.CQRS.Querys.Requests
{
    public record GetAllAnswersByQuestionIdQuery(int QuestionId) : IRequest<IEnumerable<Answer>>;
   
}
