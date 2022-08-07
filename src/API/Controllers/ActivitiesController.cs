using Application.Activities.Commands.CreateActivity;
using Application.Activities.Commands.DeleteActivity;
using Application.Activities.Commands.UpdateActivity;
using Application.Activities.Queries.GetActivities;
using Application.Activities.Queries.GetActivityById;
using Application.Common.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ActivitiesController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<ActivityDto>>> GetActivities()
        {
            return await Mediator.Send(new GetActivitiesQuery());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ActivityDto>> GetActivity(int id)
        {
            return await Mediator.Send(new GetActivityByIdQuery(id));
        }

        [HttpPost]
        public async Task<ActionResult<int>> PostActivity(CreateActivityCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateActivity(int id, UpdateActivityCommand command)
        {
            if (command.Id != id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteActivity(int id)
        {
            await Mediator.Send(new DeleteActivityCommand(id));

            return NoContent();
        }
    }
}
