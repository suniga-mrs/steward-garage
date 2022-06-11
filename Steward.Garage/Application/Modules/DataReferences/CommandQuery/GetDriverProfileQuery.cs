using AutoMapper;
using MediatR;
using Steward.Garage.Application.Modules.DataReferences.DTO;
using Steward.Garage.Application.Shared.Interfaces;

namespace Steward.Garage.Application.Modules.DataReferences.CommandQuery
{
    public class GetDriverProfileQuery : IRequest<DriverDTO>
    {
        public int DriverId { get; set; } = 0;
    }

    public class GetDriverProfileQueryHandler : IRequestHandler<GetDriverProfileQuery, DriverDTO>
    {
        private IApplicationDbContext _context;
        private IMapper _mapper;

        public GetDriverProfileQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DriverDTO> Handle(GetDriverProfileQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Drivers
                 .FindAsync(new object[] { request.DriverId }, cancellationToken);

            if (entity == null)
            {
                throw new KeyNotFoundException("Driver not found.");
            }

            return _mapper.Map<DriverDTO>(entity);
        }
    }


}
