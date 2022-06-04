using FluentValidation;
using MediatR;
using Steward.WheelBox.Application.Modules.DataReferences.Interfaces;
using Steward.WheelBox.Application.Shared.Interfaces;

namespace Steward.WheelBox.Application.Modules.DataReferences.CommandQuery
{
    public class DeleteDriverCommand : IRequest<int>
    {
        public int DriverId { get; }
    }


    public class DeleteDriverCommandValidator : AbstractValidator<DeleteDriverCommand>
    {
        public DeleteDriverCommandValidator()
        {
            RuleFor(x => x.DriverId)
                .NotEmpty().WithMessage("Unique identifier required.");
        }

    }

    public class DeleteDriverCommandHandler : IRequestHandler<DeleteDriverCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IDriverService _driverService;
        public DeleteDriverCommandHandler(IApplicationDbContext context, IDriverService driverService)
        {
            _context = context;
            _driverService = driverService;
        }

        public async Task<int> Handle(DeleteDriverCommand request, CancellationToken cancellationToken = default)
        {
            await using var tx = await _context.Database.BeginTransactionAsync();

            try
            {
                await _driverService.DeleteDriver(request, cancellationToken);
                await tx.CommitAsync();
                return request.DriverId;
            }
            catch (Exception e)
            {
                await tx.RollbackAsync();
                throw;
            }
        }

    }

}
