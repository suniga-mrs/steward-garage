using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Steward.WheelBox.Application.Modules.DataReferences.CommandQuery;
using Steward.WheelBox.Application.Modules.DataReferences.DTO;
using Steward.WheelBox.Application.Shared.Models;

namespace Steward.WheelBox.Application.Modules.DataReferences.Controllers
{
    [Route("api/units")]
    [ApiController]
    public class UnitsController : ControllerBase
    {
        private readonly ISender _sender;

        public UnitsController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<ActionResult<AppResponse<IEnumerable<UnitDTO>>>> GetUnits([FromQuery] GetUnitListQuery request)
        {
            var result = await _sender.Send(request);
            return Ok(new AppResponse<IEnumerable<UnitDTO>>(result.Data, result.Pagination));
        }

        [HttpPost]
        public async Task<ActionResult<AppResponse<UnitDTO>>> CreateUpdateUnit([FromBody] CreateUpdateUnitCommand command)
        {
            var result = await _sender.Send(command);
            return Ok(new AppResponse<UnitDTO>(result));
        }

        [HttpDelete]
        public async Task<ActionResult<AppResponse<int>>> DeleteUnit([FromQuery] DeleteUnitCommand command)
        {
            var result = await _sender.Send(command);
            return Ok(new AppResponse<int>(result));
        }

    }
}
