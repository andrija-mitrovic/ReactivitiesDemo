using MediatR;

namespace Application.Activities.Commands.UpdateActivity
{
    public class UpdateActivityCommand : IRequest
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public DateTime Date { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
        public string? City { get; set; }
        public string? Venue { get; set; }
    }
}
