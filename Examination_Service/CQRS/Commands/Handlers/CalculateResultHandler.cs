using Examination_Service.CQRS.Commands.Requests;
using Examination_Service.DTOs;
using Examination_Service.Services;
using MediatR;

namespace Examination_Service.CQRS.Commands.Handlers
{
    public class CalculateResultHandler : IRequestHandler<CalculateResultCommand, double>
    {
        public CalculateResultHandler(ExamService examService)
        {
            ExamService = examService;
        }

        public ExamService ExamService { get; }

        public async Task<double> Handle(CalculateResultCommand request, CancellationToken cancellationToken)
        {
            return await ExamService.CalculateResultAsync(request.calculateResultDto);
        }
    }
}
