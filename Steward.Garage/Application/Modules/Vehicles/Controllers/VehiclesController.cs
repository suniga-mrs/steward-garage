using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Steward.Garage.Application.Shared.Models;
using Steward.Garage.Application.Modules.Vehicles.CommandQuery;
using Steward.Garage.Application.Modules.Vehicles.DTO;
using Steward.Garage.Application.Modules.Vehicles.Entities;
using Steward.Garage.Infrastructure.Persistence;

namespace Steward.Garage.Application.Modules.Vehicles.Controllers
{
    [Route("api/vehicles")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly ISender _sender;

        public VehiclesController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<ActionResult<AppResponse<IEnumerable<VehicleDTO>>>> GetVehicles([FromQuery] GetVehicleListQuery request)
        {
            var result = await _sender.Send(request);
            return Ok(new AppResponse<IEnumerable<VehicleDTO>>(result.Data, result.Pagination));
        }

        [HttpGet("profile")]
        public async Task<ActionResult<AppResponse<VehicleDTO>>> GetVehicleProfile([FromQuery] GetVehicleProfileQuery request)
        {
            var result = await _sender.Send(request);
            return Ok(new AppResponse<VehicleDTO>(result));
        }

        [HttpPost]
        public async Task<ActionResult<AppResponse<VehicleDTO>>> CreateUpdateVehicle([FromBody] CreateUpdateVehicleCommand command)
        {
            var result = await _sender.Send(command);
            return Ok(new AppResponse<VehicleDTO>(result));
        }

        [HttpDelete]
        public async Task<ActionResult<AppResponse<int>>> DeleteVehicle([FromQuery] DeleteVehicleCommand command)
        {
            var result = await _sender.Send(command);
            return Ok(new AppResponse<int>(result));
        }


    }
}
