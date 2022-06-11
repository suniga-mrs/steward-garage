using Steward.Garage.Application.Modules.DataReferences.CommandQuery;
using Steward.Garage.Application.Modules.DataReferences.DTO;

namespace Steward.Garage.Application.Modules.DataReferences.Interfaces
{
    public interface IUnitService
    {

        Task<UnitDTO> CreateUnit(CreateUpdateUnitCommand request, CancellationToken ct);
        Task<UnitDTO> UpdateUnit(CreateUpdateUnitCommand request, CancellationToken ct);
        Task<int> DeleteUnit(DeleteUnitCommand request, CancellationToken ct);
    }
}
