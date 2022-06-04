using FluentValidation;
using MediatR;
using Steward.WheelBox.Application.Modules.Vehicles.DTO;
using Steward.WheelBox.Application.Modules.Vehicles.Interfaces;
using Steward.WheelBox.Application.Shared.Interfaces;

namespace Steward.WheelBox.Application.Modules.Vehicles.CommandQuery
{
    public class CreateUpdateVehicleCommand : IRequest<VehicleDTO>
    {
        public int VehicleId { get; set; } = 0;
        public string Make { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public Int16 Year { get; set; } = 0;
        public string PlateNo { get; set; } = string.Empty;
        public string ChassisNo { get; set; } = string.Empty;
        public string EngineNo { get; set; } = string.Empty;
    }

    public class CreateUpdateVehicleCommandValidator : AbstractValidator<CreateUpdateVehicleCommand>
    {

        public CreateUpdateVehicleCommandValidator()
        {

            RuleFor(x => x.Make)
                .MaximumLength(50).WithMessage("Make exceeds max length of 50.");

            RuleFor(x => x.Model)
                .MaximumLength(50).WithMessage("Model exceeds max length of 50.");

            RuleFor(x => x.PlateNo)
                .MaximumLength(100).WithMessage("Plate No. exceeds max length of 100.");

            RuleFor(x => x.ChassisNo)
                .MaximumLength(100).WithMessage("Chassis No. exceeds max length of 100.");

            RuleFor(x => x.EngineNo)
                .MaximumLength(100).WithMessage("Engine No. exceeds max length of 100.");
        }

    }

    public class CreateUpdateVehicleCommandHandler : IRequestHandler<CreateUpdateVehicleCommand, VehicleDTO>
    {
        private IApplicationDbContext _context;
        private IVehicleService _vehicleService;
        public CreateUpdateVehicleCommandHandler(IApplicationDbContext context, IVehicleService vehicleService)
        {
            _context = context;
            _vehicleService = vehicleService;
        }

        public async Task<VehicleDTO> Handle(CreateUpdateVehicleCommand request, CancellationToken cancellationToken)
        {
            await using var tx = await _context.Database.BeginTransactionAsync();

            try
            {

                VehicleDTO vehicle;

                if (request.VehicleId != 0)
                {
                    vehicle = await _vehicleService.UpdateVehicle(request, cancellationToken);
                }
                else
                {
                    vehicle = await _vehicleService.CreateVehicle(request, cancellationToken); 
                }                
                
                await tx.CommitAsync();

                return vehicle;

            }
            catch(Exception e)
            {
                await tx.RollbackAsync();
                throw;
            }
        }
    }
}
