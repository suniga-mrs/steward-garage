using Steward.Garage.Application.Modules.DataReferences.CommandQuery;
using Steward.Garage.Application.Modules.DataReferences.DTO;

namespace Steward.Garage.Application.Modules.DataReferences.Interfaces
{
    public interface IDriverService
    {
        Task<DriverDTO> CreateDriver(CreateUpdateDriverCommand request, CancellationToken ct);
        Task<DriverDTO> UpdateDriver(CreateUpdateDriverCommand request, CancellationToken ct);
        Task<int> DeleteDriver(DeleteDriverCommand request, CancellationToken ct);
    }
}
