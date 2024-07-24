using Examination_Service.CQRS.Commands.Requests;
using Examination_Service.Services;
using MediatR;

namespace Examination_Service.CQRS.Commands.Handlers
{
    public class DeleteExamHandler : IRequestHandler<DeleteExamCommand, bool>
    {
        public DeleteExamHandler(ExamService examService)
        {
            ExamService = examService;
        }

        public ExamService ExamService { get; }

        public async Task<bool> Handle(DeleteExamCommand request, CancellationToken cancellationToken)
        {
            return await ExamService.DeleteExamAsync(request.examid);
        }
    }
}
