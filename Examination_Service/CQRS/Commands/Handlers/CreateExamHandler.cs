using Examination_Service.CQRS.Commands.Requests;
using Examination_Service.Models;
using Examination_Service.Services;
using MediatR;

namespace Examination_Service.CQRS.Commands.Handlers
{
    public class CreateExamHandler : IRequestHandler<CreateExamCommand, Exam>
    {
        public CreateExamHandler(ExamService examService)
        {
            ExamService = examService;
        }

        public ExamService ExamService { get; }

        public async Task<Exam> Handle(CreateExamCommand request, CancellationToken cancellationToken)
        {
            return await ExamService.CreateExamAsync(request.examDto);
        }
    }
}
