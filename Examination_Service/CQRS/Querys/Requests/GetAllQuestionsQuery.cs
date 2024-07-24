using Examination_Service.Models;
using MediatR;

namespace Examination_Service.CQRS.Querys.Requests
{
    record class GetAllQuestionsQuery : IRequest<IEnumerable<Question>>;

}
