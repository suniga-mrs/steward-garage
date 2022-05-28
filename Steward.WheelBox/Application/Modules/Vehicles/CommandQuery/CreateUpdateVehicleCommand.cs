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

    //public class CreateCourseCommandValidator : AbstractValidator<CreateUpdateVehicleCommand>
    //{

    //    public CreateCourseCommandValidator()
    //    {

    //        RuleFor(x => x.Name)
    //            .NotEmpty().WithMessage("Title is required");
    //    }

    //}

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
