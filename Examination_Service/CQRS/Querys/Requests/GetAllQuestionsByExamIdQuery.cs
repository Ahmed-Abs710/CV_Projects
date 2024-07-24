using Examination_Service.Models;
using MediatR;

namespace Examination_Service.CQRS.Querys.Requests
{
    public record GetAllQuestionsByExamIdQuery(int examid) : IRequest<IEnumerable<Question>>;
    
}
