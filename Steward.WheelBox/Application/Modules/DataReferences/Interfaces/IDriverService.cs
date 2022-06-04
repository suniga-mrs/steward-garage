using Steward.WheelBox.Application.Modules.DataReferences.CommandQuery;
using Steward.WheelBox.Application.Modules.DataReferences.DTO;

namespace Steward.WheelBox.Application.Modules.DataReferences.Interfaces
{
    public interface IDriverService
    {
        Task<DriverDTO> CreateDriver(CreateUpdateDriverCommand request, CancellationToken ct);
        Task<DriverDTO> UpdateDriver(CreateUpdateDriverCommand request, CancellationToken ct);
        Task<int> DeleteDriver(DeleteDriverCommand request, CancellationToken ct);
    }
}
