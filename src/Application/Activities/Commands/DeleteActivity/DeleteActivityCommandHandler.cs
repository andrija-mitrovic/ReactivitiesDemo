using Application.Common.Exceptions;
using Application.Common.Helpers;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Activities.Commands.DeleteActivity
{
    public class DeleteActivityCommandHandler : IRequestHandler<DeleteActivityCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly ILogger<DeleteActivityCommandHandler> _logger;

        public DeleteActivityCommandHandler(
            IApplicationDbContext context,
            ILogger<DeleteActivityCommandHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteActivityCommand request, CancellationToken cancellationToken)
        {
            var activity = await _context.Activities.FindAsync(new object[] { request.Id }, cancellationToken);

            if (activity == null)
            {
                _logger.LogError(HelperFunction.GetMethodName() + " - Activity with Id: {ActivityId} not found", activity!.Id);
                throw new NotFoundException(nameof(Activity), request.Id);
            }

            _context.Activities.Remove(activity!);

            await _context.SaveChangesAsync(cancellationToken);

            _logger.LogInformation("Activity {ActivityId} is successfully deleted.", activity.Id);

            return Unit.Value;
        }
    }
}
