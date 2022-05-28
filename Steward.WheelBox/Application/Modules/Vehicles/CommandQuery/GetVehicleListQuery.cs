using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Steward.WheelBox.Application.Shared.Interfaces;
using Steward.WheelBox.Application.Shared.Models;
using Steward.WheelBox.Application.Modules.Vehicles.DTO;
using Steward.WheelBox.Application.Modules.Vehicles.Entities;
using Steward.WheelBox.Core.Extensions;

namespace Steward.WheelBox.Application.Modules.Vehicles.CommandQuery
{
    public class GetVehicleListQuery : PagingQuery, IRequest<PaginatedResult<IEnumerable<VehicleDTO>>>
    {
        public string Make { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public Int16 Year { get; set; } = 0;
        public string PlateNo { get; set; } = string.Empty;
        public string ChassisNo { get; set; } = string.Empty;
        public string EngineNo { get; set; } = string.Empty;
    }

    public class GetVehicleListQueryHandler : IRequestHandler<GetVehicleListQuery, PaginatedResult<IEnumerable<VehicleDTO>>>
    {
        IApplicationDbContext _context;
        IMapper _mapper;

        public GetVehicleListQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<PaginatedResult<IEnumerable<VehicleDTO>>> Handle(GetVehicleListQuery request, CancellationToken cancellationToken)
        {

            var _make = request.Make.Trim().ToUpper();
            var _model = request.Model.Trim().ToUpper();
            var _plateNo = request.PlateNo.Trim().ToUpper();
            var _chassisNo = request.ChassisNo.Trim().ToUpper();
            var _engineNo = request.EngineNo.Trim().ToUpper();
            var _year = request.Year;

            var queryResult = await _context.Vehicles
                .Where(o =>
                    o.IsDeleted == false &&
                    (
                        (String.IsNullOrEmpty(_make) && o.VehicleId != 0)
                        || (!string.IsNullOrEmpty(_make) && EF.Functions.Like(o.Make, $"%{_make}%"))
                    )
                    &&
                    (
                        (String.IsNullOrEmpty(_model) && o.VehicleId != 0)
                        || (!string.IsNullOrEmpty(_model) && EF.Functions.Like(o.Model, $"%{_model}%"))
                    )
                    &&
                    (
                        (String.IsNullOrEmpty(_plateNo) && o.VehicleId != 0)
                        || (!string.IsNullOrEmpty(_model) && EF.Functions.Like(o.NormalizedPlateNo, $"%{_plateNo}%"))
                    )
                    &&
                    (
                        (String.IsNullOrEmpty(_chassisNo) && o.VehicleId != 0)
                        || (!string.IsNullOrEmpty(_model) && EF.Functions.Like(o.NormalizedChassisNo, $"%{_chassisNo}%"))
                    )
                    &&
                    (
                        (String.IsNullOrEmpty(_engineNo) && o.VehicleId != 0)
                        || (!string.IsNullOrEmpty(_model) && EF.Functions.Like(o.NormalizedEngineNo, $"%{_engineNo}%"))
                    )
                    &&
                    (
                        ( _year == 0 && o.VehicleId != 0)
                        || (_year != 0 && o.Year == _year)
                    )
                )
                .ToPaginatedQueryResultAsync<Vehicle, VehicleDTO>(_mapper.ConfigurationProvider, request.Page, request.PerPage);

            return queryResult;
        }
    }
}
