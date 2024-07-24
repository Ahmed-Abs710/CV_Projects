using Examination_Service.CQRS.Commands.Requests;
using Examination_Service.Models;
using Examination_Service.Services;
using MediatR;

namespace Examination_Service.CQRS.Commands.Handlers
{
    public class CreateExamResultHandler : IRequestHandler<CreateExamResultCommand, ExamResult>
    {
        public CreateExamResultHandler(ExamService examService)
        {
            ExamService = examService;
        }

        public ExamService ExamService { get; }

        public async Task<ExamResult> Handle(CreateExamResultCommand request, CancellationToken cancellationToken)
        {
            return await ExamService.CreateExamResultAsync(request.CalculateResultDto);
        }
    }
}
