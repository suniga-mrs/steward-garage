using FluentValidation;
using MediatR;
using Steward.WheelBox.Application.Modules.Vehicles.Interfaces;
using Steward.WheelBox.Application.Shared.Interfaces;

namespace Steward.WheelBox.Application.Modules.Vehicles.CommandQuery
{
    public class DeleteVehicleCommand : IRequest<int>
    {
        public int VehicleId { get; set; } = 0;
    }

    public class DeleteVehicleCommandValidator : AbstractValidator<DeleteVehicleCommand>
    {
        public DeleteVehicleCommandValidator()
        {
            RuleFor(x => x.VehicleId)
                .NotEmpty().WithMessage("Unique identifier required.");
        }

    }

    public class DeleteVehicleCommandHandler : IRequestHandler<DeleteVehicleCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IVehicleService _vehicleService;
        public DeleteVehicleCommandHandler(IApplicationDbContext context, IVehicleService vehicleService)
        {
            _context = context;
            _vehicleService = vehicleService;
        }

        public async Task<int> Handle(DeleteVehicleCommand request, CancellationToken cancellationToken = default)
        {
            await using var tx = await _context.Database.BeginTransactionAsync();

            try
            {
                var entityVehicle = await _context.Vehicles.FindAsync(new object[] { request.VehicleId }, cancellationToken);
                if (entityVehicle == null)
                {
                    throw new KeyNotFoundException("Vehicle not found");
                }


                _context.Vehicles.Remove(entityVehicle);

                await _context.SaveChangesAsync(cancellationToken);

                await tx.CommitAsync();

                return request.VehicleId;

            }
            catch (Exception e)
            {
                await tx.RollbackAsync();
                throw;
            }
        }

    }

}
