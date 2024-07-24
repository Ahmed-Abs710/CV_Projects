using Examination_Service.CQRS.Querys.Requests;
using Examination_Service.Models;
using Examination_Service.Services;
using MediatR;

namespace Examination_Service.CQRS.Querys.Handlers
{
    public class GetAllExamsHandler : IRequestHandler<GetAllExamsQuery, IEnumerable<Exam>>
    {
        public GetAllExamsHandler(ExamService examService)
        {
            ExamService = examService;
        }

        public ExamService ExamService { get; }

        public Task<IEnumerable<Exam>> Handle(GetAllExamsQuery request, CancellationToken cancellationToken)
        {
            return ExamService.GetAllExamsAsync();
        }
    }
}
