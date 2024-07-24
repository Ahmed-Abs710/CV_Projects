using Examination_Service.CQRS.Querys.Requests;
using Examination_Service.Models;
using Examination_Service.Services;
using MediatR;

namespace Examination_Service.CQRS.Querys.Handlers
{
    public class GetExamByIdHandler : IRequestHandler<GetExamByIdQuery, Exam>
    {
        public GetExamByIdHandler(ExamService examService)
        {
            ExamService = examService;
        }

        public ExamService ExamService { get; }

        public async Task<Exam> Handle(GetExamByIdQuery request, CancellationToken cancellationToken)
        {
            return await ExamService.GetExamByIdAsync(request.examid);
        }
    }
}
