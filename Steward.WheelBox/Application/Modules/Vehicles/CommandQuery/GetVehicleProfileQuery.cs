using AutoMapper;
using MediatR;
using Steward.WheelBox.Application.Shared.Interfaces;
using Steward.WheelBox.Application.Modules.Vehicles.DTO;

namespace Steward.WheelBox.Application.Modules.Vehicles.CommandQuery
{
    public class GetVehicleProfileQuery : IRequest<VehicleDTO>
    {
        public int VehicleID { get; set; } = 0;
    }

    public class GetVehicleProfileQueryHandler : IRequestHandler<GetVehicleProfileQuery, VehicleDTO>
    {
        IApplicationDbContext _context;
        IMapper _mapper;

        public GetVehicleProfileQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<VehicleDTO> Handle(GetVehicleProfileQuery request, CancellationToken cancellationToken = default)
        {
            var entity = await _context.Vehicles
                 .FindAsync(new object[] { request.VehicleID }, cancellationToken);

            if (entity == null)
            {
                throw new KeyNotFoundException("Vehicle not found.");
            }

            return _mapper.Map<VehicleDTO>(entity);

        }
    }
}
