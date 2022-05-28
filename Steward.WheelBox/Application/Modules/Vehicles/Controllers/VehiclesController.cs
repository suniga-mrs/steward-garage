using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Steward.WheelBox.Application.Shared.Models;
using Steward.WheelBox.Application.Modules.Vehicles.CommandQuery;
using Steward.WheelBox.Application.Modules.Vehicles.DTO;
using Steward.WheelBox.Application.Modules.Vehicles.Entities;
using Steward.WheelBox.Infrastructure.Persistence;

namespace Steward.WheelBox.Application.Modules.Vehicles.Controllers
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


        //// PUT: api/Vehicles/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutVehicle(int id, Vehicle vehicle)
        //{
        //    if (id != vehicle.VehicleId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(vehicle).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!VehicleExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Vehicles
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Vehicle>> PostVehicle(VehicleDTO command)
        //{
        //  if (_context.Vehicles == null)
        //  {
        //      return Problem("Entity set 'ApplicationDbContext.Vehicles'  is null.");
        //  }

        //    var vehicle = _mapper.Map<Vehicle>(command);

        //    _context.Vehicles.Add(vehicle);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetVehicle", new { id = vehicle.VehicleId }, vehicle);
        //}

        //// DELETE: api/Vehicles/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteVehicle(int id)
        //{
        //    if (_context.Vehicles == null)
        //    {
        //        return NotFound();
        //    }
        //    var vehicle = await _context.Vehicles.FindAsync(id);
        //    if (vehicle == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Vehicles.Remove(vehicle);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool VehicleExists(int id)
        //{
        //    return (_context.Vehicles?.Any(e => e.VehicleId == id)).GetValueOrDefault();
        //}
    }
}
