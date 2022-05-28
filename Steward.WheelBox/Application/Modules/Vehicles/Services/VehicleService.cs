using AutoMapper;
using Steward.WheelBox.Application.Shared.Interfaces;
using Steward.WheelBox.Application.Modules.Vehicles.CommandQuery;
using Steward.WheelBox.Application.Modules.Vehicles.DTO;
using Steward.WheelBox.Application.Modules.Vehicles.Entities;
using Steward.WheelBox.Application.Modules.Vehicles.Interfaces;
using Steward.WheelBox.Core.Helpers;

namespace Steward.WheelBox.Application.Modules.Vehicles.Services
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

                make: string.IsNullOrEmpty(request.Make) ? entityVehicle.Make : request.Make,
                model: string.IsNullOrEmpty(request.Model) ? entityVehicle.Model : request.Model,
                year: request.Year != 0 ? entityVehicle.Year : request.Year,
                plateNo: string.IsNullOrEmpty(request.PlateNo) ? entityVehicle.PlateNo : request.PlateNo,
                chassisNo: string.IsNullOrEmpty(request.ChassisNo) ? entityVehicle.ChassisNo : request.ChassisNo,
                engineNo: string.IsNullOrEmpty(request.EngineNo) ? entityVehicle.EngineNo : request.EngineNo
            );


            await _context.SaveChangesAsync(ct);

            return _mapper.Map<VehicleDTO>(entityVehicle);

        }
    }
}
