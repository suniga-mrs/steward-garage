using Steward.Garage.Application.Shared.Mappings;
using Steward.Garage.Application.Modules.Vehicles.Entities;
using Steward.Garage.Application.Shared.Models;

namespace Steward.Garage.Application.Modules.Vehicles.DTO
{
    public class VehicleDTO : BaseAuditableEntityDTO, IMapFrom<Vehicle>
    {
        public int VehicleId { get; set; }
        public Guid VehicleGuid { get; set; }
        public string Make { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public Int16 Year { get; set; } = 0;
        public string PlateNo { get; set; } = string.Empty;
        public string ChassisNo { get; set; } = string.Empty;
        public string EngineNo { get; set; } = string.Empty;

    }
}
