using MediatR;

namespace Examination_Service.CQRS.Commands.Requests
{
    public record DeleteQuestionCommand(int QuestionId) : IRequest<bool>;

}
