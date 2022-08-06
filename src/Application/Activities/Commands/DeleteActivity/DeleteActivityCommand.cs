using MediatR;

namespace Application.Activities.Commands.DeleteActivity
{
    public record DeleteActivityCommand(int Id) : IRequest { }
}
