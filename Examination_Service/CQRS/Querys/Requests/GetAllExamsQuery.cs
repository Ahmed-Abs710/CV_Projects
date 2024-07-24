using Examination_Service.Models;
using MediatR;

namespace Examination_Service.CQRS.Querys.Requests
{
    public class GetAllExamsQuery : IRequest<IEnumerable<Exam>>;
  
}
