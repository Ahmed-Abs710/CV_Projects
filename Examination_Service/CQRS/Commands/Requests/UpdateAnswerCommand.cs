using Examination_Service.DTOs;
using Examination_Service.Models;
using MediatR;

namespace Examination_Service.CQRS.Commands.Requests
{
    public record UpdateAnswerCommand(int answerid, UpdateAnswerDto updateAnswerDto) : IRequest<Answer>;

}
