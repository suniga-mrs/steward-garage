using Steward.WheelBox.Application.Modules.Vehicles.CommandQuery;
using Steward.WheelBox.Application.Modules.Vehicles.DTO;

namespace Steward.WheelBox.Application.Modules.Vehicles.Interfaces
{
    public interface IVehicleService
    {
        Task<VehicleDTO> CreateVehicle(CreateUpdateVehicleCommand request, CancellationToken ct);
        Task<VehicleDTO> UpdateVehicle(CreateUpdateVehicleCommand request, CancellationToken ct);
        

    }
}
