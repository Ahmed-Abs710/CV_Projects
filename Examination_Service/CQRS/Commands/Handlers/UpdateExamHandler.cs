using Examination_Service.CQRS.Commands.Requests;
using Examination_Service.Models;
using Examination_Service.Services;
using MediatR;

namespace Examination_Service.CQRS.Commands.Handlers
{
    public class UpdateExamHandler : IRequestHandler<UpdateExamCommand, Exam>
    {
        public UpdateExamHandler(ExamService examService)
        {
            ExamService = examService;
        }

        public ExamService ExamService { get; }

        public async Task<Exam> Handle(UpdateExamCommand request, CancellationToken cancellationToken)
        {
            return await ExamService.UpdateExamAsync(request.examid, request.updateExamDto);
        }
    }
}
