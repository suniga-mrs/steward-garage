using Steward.Garage.Application.Modules.Vehicles.CommandQuery;
using Steward.Garage.Application.Modules.Vehicles.DTO;

namespace Steward.Garage.Application.Modules.Vehicles.Interfaces
{
    public interface IVehicleService
    {
        Task<VehicleDTO> CreateVehicle(CreateUpdateVehicleCommand request, CancellationToken ct);
        Task<VehicleDTO> UpdateVehicle(CreateUpdateVehicleCommand request, CancellationToken ct);
        Task<int> DeleteVehicle(DeleteVehicleCommand request, CancellationToken ct);
        

    }
}
