using AutoMapper;
using Steward.Garage.Application.Modules.DataReferences.CommandQuery;
using Steward.Garage.Application.Modules.DataReferences.DTO;
using Steward.Garage.Application.Modules.DataReferences.Entities;
using Steward.Garage.Application.Modules.DataReferences.Interfaces;
using Steward.Garage.Application.Shared.Interfaces;

namespace Steward.Garage.Application.Modules.DataReferences.Services
{
    public class UnitService : IUnitService
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UnitService(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public async Task<UnitDTO> CreateUnit(CreateUpdateUnitCommand request, CancellationToken ct)
        {
            var newUnit = new Unit(
                 name: request.Name,
                 prefix: request.Prefix,
                 suffix: request.Suffix
             );

            _context.Units.Add(newUnit);
            await _context.SaveChangesAsync(ct);

            return _mapper.Map<UnitDTO>(newUnit);

        }

        public async Task<int> DeleteUnit(DeleteUnitCommand request, CancellationToken ct)
        {
            var entityUnit = await _context.Units.FindAsync(new object[] { request.UnitId }, ct);

            if (entityUnit == null)
            {
                throw new KeyNotFoundException("Unit not found");
            }

            _context.Units.Remove(entityUnit);

            await _context.SaveChangesAsync(ct);

            return request.UnitId;
        }

        public async Task<UnitDTO> UpdateUnit(CreateUpdateUnitCommand request, CancellationToken ct)
        {

            var entityUnit = await _context.Units.FindAsync(new object[] { request.UnitId }, ct);

            if (entityUnit == null)
            {
                throw new KeyNotFoundException("Unit not found");
            }

            entityUnit.UpdateEntity(
                 name: request.Name,
                 prefix: request.Prefix,
                 suffix: request.Suffix
                );


            await _context.SaveChangesAsync(ct);

            return _mapper.Map<UnitDTO>(entityUnit);

        }
    }
}
