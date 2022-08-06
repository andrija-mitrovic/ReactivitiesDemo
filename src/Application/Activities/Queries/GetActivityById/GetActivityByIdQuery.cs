using Application.Common.DTOs;
using MediatR;

namespace Application.Activities.Queries.GetActivityById
{
    public record GetActivityByIdQuery(int Id) : IRequest<ActivityDto>{}
}
