using MediatR;

namespace Examination_Service.CQRS.Commands.Requests
{
    public record DeleteExamCommand(int examid) : IRequest<bool>;

}
