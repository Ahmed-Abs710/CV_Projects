using Examination_Service.DTOs;
using MediatR;

namespace Examination_Service.CQRS.Commands.Requests
{
    public record CalculateResultCommand(CalculateResultDto calculateResultDto) : IRequest<double>;

}
