using Steward.WheelBox.Application.Modules.DataReferences.Entities;
using Steward.WheelBox.Application.Shared.Mappings;

namespace Steward.WheelBox.Application.Modules.DataReferences.DTO
{
    public class DriverDTO : IMapFrom<Driver>
    {
        public int DriverId { get; }
        public Guid DriverGuid { get; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string FullName { get; private set; } = string.Empty;
        public string Suffix { get; set; } = string.Empty;
        public string LicenseNo { get; set; } = string.Empty;
        public DateTime Birthdate { get; set; } = DateTime.MinValue;
        public DateTime LicenseExpiry { get; set; } = DateTime.MinValue;

    }
}
