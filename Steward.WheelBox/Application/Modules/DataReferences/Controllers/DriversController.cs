using MediatR;
using Microsoft.AspNetCore.Mvc;
using Steward.WheelBox.Application.Modules.DataReferences.CommandQuery;
using Steward.WheelBox.Application.Modules.DataReferences.DTO;
using Steward.WheelBox.Application.Shared.Models;

namespace Steward.WheelBox.Application.Modules.DataReferences.Controllers
{
    [Route("api/drivers")]
    [ApiController]
    public class DriversController : ControllerBase
    {
        private readonly ISender _sender;

        public DriversController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<ActionResult<AppResponse<IEnumerable<DriverDTO>>>> GetDrivers([FromQuery] GetDriverListQuery request)
        {
            var result = await _sender.Send(request);
            return Ok(new AppResponse<IEnumerable<DriverDTO>>(result.Data, result.Pagination));
        }

        [HttpGet("profile")]
        public async Task<ActionResult<AppResponse<IEnumerable<DriverDTO>>>> GetDriverProfile([FromQuery] GetDriverProfileQuery request)
        {
            var result = await _sender.Send(request);
            return Ok(new AppResponse<DriverDTO>(result));
        }

        [HttpPost]
        public async Task<ActionResult<AppResponse<DriverDTO>>> CreateUpdateDriver([FromBody] CreateUpdateDriverCommand command)
        {
            var result = await _sender.Send(command);
            return Ok(new AppResponse<DriverDTO>(result));
        }

        [HttpDelete]
        public async Task<ActionResult<AppResponse<int>>> DeleteDriver([FromQuery] DeleteDriverCommand command)
        {
            var result = await _sender.Send(command);
            return Ok(new AppResponse<int>(result));
        }

    }
}
