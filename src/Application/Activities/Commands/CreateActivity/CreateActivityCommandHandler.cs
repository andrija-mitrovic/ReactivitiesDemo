using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Activities.Commands.CreateActivity
{
    public class CreateActivityCommandHandler : IRequestHandler<CreateActivityCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateActivityCommandHandler> _logger;

        public CreateActivityCommandHandler(
            IApplicationDbContext context, 
            IMapper mapper,
            ILogger<CreateActivityCommandHandler> logger)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateActivityCommand request, CancellationToken cancellationToken)
        {
            var activity = _mapper.Map<Activity>(request);

            await _context.Activities.AddAsync(activity);

            await _context.SaveChangesAsync(cancellationToken);

            _logger.LogInformation("Activity {ActivityId} is successfully created.", activity.Id);

            return activity.Id;
        }
    }
}
