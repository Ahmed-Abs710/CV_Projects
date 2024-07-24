using MediatR;

namespace Examination_Service.CQRS.Commands.Requests
{
    public record DeleteAnswerCommand(int AnswerId) : IRequest<bool>;

}
