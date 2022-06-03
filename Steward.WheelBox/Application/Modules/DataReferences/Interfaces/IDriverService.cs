using Steward.WheelBox.Application.Modules.DataReferences.DTO;

namespace Steward.WheelBox.Application.Modules.DataReferences.Interfaces
{
    public interface IDriverService
    {
        Task<DriverDTO> CreateDriver();
        Task<DriverDTO> UpdateDriver();
        Task<DriverDTO> DeleteDriver();
    }
}
