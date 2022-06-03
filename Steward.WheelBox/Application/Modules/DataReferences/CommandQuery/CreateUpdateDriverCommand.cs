using MediatR;
using Steward.WheelBox.Application.Modules.DataReferences.DTO;

namespace Steward.WheelBox.Application.Modules.DataReferences.CommandQuery
{
    public class CreateUpdateDriverCommand : IRequest<DriverDTO>
    {
        public int DriverId { get; }
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
