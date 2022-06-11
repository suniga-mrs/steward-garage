using Steward.Garage.Application.Modules.Drivers.CommandQuery;
using Steward.Garage.Application.Modules.Drivers.DTO;

namespace Steward.Garage.Application.Modules.Drivers.Interfaces
{
    public interface IDriverService
    {
        Task<DriverDTO> CreateDriver(CreateUpdateDriverCommand request, CancellationToken ct);
        Task<DriverDTO> UpdateDriver(CreateUpdateDriverCommand request, CancellationToken ct);
        Task<int> DeleteDriver(DeleteDriverCommand request, CancellationToken ct);
    }
}
