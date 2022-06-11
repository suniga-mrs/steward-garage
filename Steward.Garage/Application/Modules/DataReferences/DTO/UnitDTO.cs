using Steward.Garage.Application.Modules.DataReferences.Entities;
using Steward.Garage.Application.Shared.Mappings;
using Steward.Garage.Application.Shared.Models;

namespace Steward.Garage.Application.Modules.DataReferences.DTO
{
    public class UnitDTO : BaseAuditableEntityDTO, IMapFrom<Unit>
    {
        public int UnitId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Prefix { get; set; } = string.Empty;
        public string Suffix { get; set; } = string.Empty;

    }
}
