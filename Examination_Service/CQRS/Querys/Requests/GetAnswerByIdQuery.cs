using Examination_Service.Models;
using MediatR;

namespace Examination_Service.CQRS.Querys.Requests
{
    public record GetAnswerByIdQuery(int AnswerId) : IRequest<Answer>;

}
