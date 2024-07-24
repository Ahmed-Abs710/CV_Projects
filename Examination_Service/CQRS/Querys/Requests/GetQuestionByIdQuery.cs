using Examination_Service.Models;
using MediatR;

namespace Examination_Service.CQRS.Querys.Requests
{
    public record GetQuestionByIdQuery(int QuestionId) : IRequest<Question>;

}
