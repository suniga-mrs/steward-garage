using Steward.WheelBox.Application.Modules.DataReferences.CommandQuery;
using Steward.WheelBox.Application.Modules.DataReferences.DTO;

namespace Steward.WheelBox.Application.Modules.DataReferences.Interfaces
{
    public interface IUnitService
    {

        Task<UnitDTO> CreateUnit(CreateUpdateUnitCommand request, CancellationToken ct);
        Task<UnitDTO> UpdateUnit(CreateUpdateUnitCommand request, CancellationToken ct);
        Task<int> DeleteUnit(DeleteUnitCommand request, CancellationToken ct);
    }
}
