using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Steward.WheelBox.Application.Modules.DataReferences.DTO;
using Steward.WheelBox.Application.Shared.Interfaces;
using Steward.WheelBox.Application.Shared.Models;
using Steward.WheelBox.Core.Extensions;
using Unit = Steward.WheelBox.Application.Modules.DataReferences.Entities.Unit;

namespace Steward.WheelBox.Application.Modules.DataReferences.CommandQuery
{
    public class GetUnitListQuery : PagingQuery, IRequest<PaginatedResult<IEnumerable<UnitDTO>>>
    {
        public string Name { get; set; } = string.Empty;
        public string Prefix { get; set; } = string.Empty;
        public string Suffix { get; set; } = string.Empty;

    }

    public class GetUnitListQueryHandler : IRequestHandler<GetUnitListQuery, PaginatedResult<IEnumerable<UnitDTO>>>
    {
        private IApplicationDbContext _context;
        private IMapper _mapper;

        public GetUnitListQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaginatedResult<IEnumerable<UnitDTO>>> Handle(GetUnitListQuery request, CancellationToken cancellationToken)
        {

            var _name = request.Name;
            var _prefix = request.Prefix;
            var _suffix = request.Suffix;

            var queryResult = await _context.Units
                .Where(o =>
                    o.IsDeleted == false &&
                    (
                        (String.IsNullOrEmpty(_name) && o.UnitId != 0)
                        || (!string.IsNullOrEmpty(_name) && EF.Functions.Like(o.Name, $"%{_name}%"))
                    )
                    &&
                    (
                        (String.IsNullOrEmpty(_prefix) && o.UnitId != 0)
                        || (!string.IsNullOrEmpty(_prefix) && EF.Functions.Like(o.Prefix, $"%{_prefix}%"))
                    )
                    &&
                    (
                        (String.IsNullOrEmpty(_suffix) && o.UnitId != 0)
                        || (!string.IsNullOrEmpty(_suffix) && EF.Functions.Like(o.Suffix, $"%{_suffix}%"))
                    )
                )
                .ToPaginatedQueryResultAsync<Unit, UnitDTO>(_mapper.ConfigurationProvider, request.Page, request.PerPage);

            return queryResult;

        }
    }

}
