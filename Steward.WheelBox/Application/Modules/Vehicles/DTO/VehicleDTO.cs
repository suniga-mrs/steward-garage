using Steward.WheelBox.Application.Shared.Mappings;
using Steward.WheelBox.Application.Modules.Vehicles.Entities;

namespace Steward.WheelBox.Application.Modules.Vehicles.DTO
{
    public class VehicleDTO : IMapFrom<Vehicle>
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
