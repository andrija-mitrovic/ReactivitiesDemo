using Application.Common.Exceptions;
using Application.Common.Helpers;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Activities.Commands.UpdateActivity
{
    public class UpdateActivityCommandHandler : IRequestHandler<UpdateActivityCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateActivityCommandHandler> _logger;

        public UpdateActivityCommandHandler(
            IApplicationDbContext context,
            IMapper mapper,
            ILogger<UpdateActivityCommandHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateActivityCommand request, CancellationToken cancellationToken)
        {
            var activity = await _context.Activities.FindAsync(new object[] { request.Id }, cancellationToken);

            if (activity == null)
            {
                _logger.LogError(HelperFunction.GetMethodName() + " - Activity with Id: {ActivityId}", activity!.Id);
                throw new NotFoundException(nameof(Activity), request.Id);
            }

            _mapper.Map(request, activity);

            _context.Activities.Update(activity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
