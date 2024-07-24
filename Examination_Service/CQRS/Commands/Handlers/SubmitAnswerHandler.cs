using Examination_Service.CQRS.Commands.Requests;
using Examination_Service.DTOs;
using Examination_Service.Models;
using Examination_Service.Services;
using MediatR;

namespace Examination_Service.CQRS.Commands.Handlers
{
    public class SubmitAnswerHandler : IRequestHandler<SubmitAnswerCommand, StudentAnswer>
    {
        public SubmitAnswerHandler(ExamService examService)
        {
            ExamService = examService;
        }

        public ExamService ExamService { get; }

        public async Task<StudentAnswer> Handle(SubmitAnswerCommand request, CancellationToken cancellationToken)
        {
            return await ExamService.SubmitAnswerAsync(request.submitAnswerDto);
        }
    }
}
