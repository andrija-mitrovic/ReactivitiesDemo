using Application.Common.DTOs;
using MediatR;

namespace Application.Activities.Queries.GetActivities
{
    public class GetActivitiesQuery : IRequest<List<ActivityDto>>
    {
    }
}
