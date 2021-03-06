using AutoMapper;
using Steward.Garage.Application.Shared.Interfaces;
using Steward.Garage.Application.Modules.Vehicles.CommandQuery;
using Steward.Garage.Application.Modules.Vehicles.DTO;
using Steward.Garage.Application.Modules.Vehicles.Entities;
using Steward.Garage.Application.Modules.Vehicles.Interfaces;
using Steward.Garage.Core.Helpers;

namespace Steward.Garage.Application.Modules.Vehicles.Services
{
    public class VehicleService : IVehicleService
    {
        private IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public VehicleService(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public async Task<VehicleDTO> CreateVehicle(CreateUpdateVehicleCommand request, CancellationToken ct = default)
        {
            var newVehicle = new Vehicle(
                make: request.Make,
                model: request.Model,
                year: request.Year,
                plateNo: request.PlateNo,
                chassisNo: request.ChassisNo,
                engineNo: request.EngineNo
            );

            _context.Vehicles.Add(newVehicle);
            await _context.SaveChangesAsync(ct);

            return _mapper.Map<VehicleDTO>(newVehicle);

        }

        public async Task<VehicleDTO> UpdateVehicle(CreateUpdateVehicleCommand request, CancellationToken ct = default)
        {

            var entityVehicle = await _context.Vehicles.FindAsync(new object[] { request.VehicleId }, ct);
            if (entityVehicle == null)
            {
                throw new KeyNotFoundException("Vehicle not found");
            }

            entityVehicle.UpdateEntity(
                make: request.Make,
                model: request.Model,
                year: request.Year,
                plateNo: request.PlateNo,
                chassisNo: request.ChassisNo,
                engineNo: request.EngineNo
            );


            await _context.SaveChangesAsync(ct);

            return _mapper.Map<VehicleDTO>(entityVehicle);

        }

        public async Task<int> DeleteVehicle(DeleteVehicleCommand request, CancellationToken cancellationToken = default)
        {
            var entityVehicle = await _context.Vehicles.FindAsync(new object[] { request.VehicleId }, cancellationToken);
            if (entityVehicle == null)
            {
                throw new KeyNotFoundException("Vehicle not found");
            }


            _context.Vehicles.Remove(entityVehicle);

            await _context.SaveChangesAsync(cancellationToken);

            return request.VehicleId;
        }
    }
}
