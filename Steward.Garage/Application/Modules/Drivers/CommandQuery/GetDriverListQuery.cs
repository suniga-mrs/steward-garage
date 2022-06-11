using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Steward.Garage.Application.Modules.Drivers.DTO;
using Steward.Garage.Application.Modules.Drivers.Entities;
using Steward.Garage.Application.Shared.Interfaces;
using Steward.Garage.Application.Shared.Models;
using Steward.Garage.Core.Extensions;

namespace Steward.Garage.Application.Modules.Drivers.CommandQuery
{
    public class GetDriverListQuery : PagingQuery, IRequest<PaginatedResult<IEnumerable<DriverDTO>>>
    {
        public string DriverName { get; set; } = string.Empty;
        public string LicenseNo { get; set; } = string.Empty;
        public DateTime? BirthDateFrom { get; set; }
        public DateTime? BirthDateTo { get; set; }
        public DateTime? LicenseExpiryFrom { get; set; }
        public DateTime? LicenseExpiryTo { get; set; }


    }

    public class GetDriverListQueryHandler : IRequestHandler<GetDriverListQuery, PaginatedResult<IEnumerable<DriverDTO>>>
    {
        IApplicationDbContext _context;
        IMapper _mapper;
        public GetDriverListQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaginatedResult<IEnumerable<DriverDTO>>> Handle(GetDriverListQuery request, CancellationToken cancellationToken)
        {

            var _driverName = request.DriverName.Trim().ToUpper();
            var _licenseNo = request.LicenseNo.Trim().ToUpper();

            var a = Convert.ToDateTime(request.BirthDateFrom);

            var _birthDateFrom = request.BirthDateFrom.GetValueOrDefault();
            var _birthDateTo = request.BirthDateTo.GetValueOrDefault();
            var _licenseExpiryFrom = request.LicenseExpiryFrom.GetValueOrDefault();
            var _licenseExpiryTo = request.LicenseExpiryTo.GetValueOrDefault();

            var queryResult = await _context.Drivers
                .Where(o =>
                    o.IsDeleted == false &&
                    (
                        string.IsNullOrEmpty(_driverName) && o.DriverId != 0
                        || !string.IsNullOrEmpty(_driverName) && EF.Functions.Like(o.FullName, $"%{_driverName}%")
                    )
                    &&
                    (
                        string.IsNullOrEmpty(_driverName) && o.DriverId != 0
                        || !string.IsNullOrEmpty(_driverName) && EF.Functions.Like(o.FullName, $"%{_licenseNo}%")
                    )
                    &&
                    (
                        (_birthDateFrom == DateTime.MinValue || _birthDateTo == DateTime.MinValue) && o.DriverId != 0
                        ||
                        
                            (_birthDateFrom != DateTime.MinValue || _birthDateTo != DateTime.MinValue)
                            && o.Birthdate >= _birthDateFrom && o.Birthdate <= _birthDateTo
                        
                    )
                    &&
                    (
                        (_licenseExpiryFrom == DateTime.MinValue || _licenseExpiryTo == DateTime.MinValue) && o.DriverId != 0
                        ||
                        
                            (_licenseExpiryFrom != DateTime.MinValue || _licenseExpiryTo != DateTime.MinValue)
                            && o.LicenseExpiry >= _licenseExpiryFrom && o.LicenseExpiry <= _licenseExpiryTo
                        
                    )

                )
                .ToPaginatedQueryResultAsync<Driver, DriverDTO>(_mapper.ConfigurationProvider, request.Page, request.PerPage);

            return queryResult;

        }
    }
}
