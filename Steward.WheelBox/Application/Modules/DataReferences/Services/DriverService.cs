using AutoMapper;
using Steward.WheelBox.Application.Modules.DataReferences.CommandQuery;
using Steward.WheelBox.Application.Modules.DataReferences.DTO;
using Steward.WheelBox.Application.Modules.DataReferences.Entities;
using Steward.WheelBox.Application.Modules.DataReferences.Interfaces;
using Steward.WheelBox.Application.Shared.Interfaces;

namespace Steward.WheelBox.Application.Modules.DataReferences.Services
{
    public class DriverService : IDriverService
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public DriverService(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public async Task<DriverDTO> CreateDriver(CreateUpdateDriverCommand request, CancellationToken ct)
        {

            var newDriver = new Driver(
                    firstName: request.FirstName,
                    lastName: request.LastName,
                    middleName: request.MiddleName,
                    suffix: request.Suffix,
                    licenseNo: request.LicenseNo,
                    birthDate: request.Birthdate ?? null,
                    licenseExpiry: request.LicenseExpiry ?? null
                );

            _context.Drivers.Add(newDriver);
            await _context.SaveChangesAsync(ct);

            return _mapper.Map<DriverDTO>(newDriver);

        }

        public async Task<int> DeleteDriver(DeleteDriverCommand request, CancellationToken ct)
        {
            var entityDriver = await _context.Drivers.FindAsync(new object[] { request.DriverId }, ct);

            if (entityDriver == null)
            {
                throw new KeyNotFoundException("Driver not found");
            }

            _context.Drivers.Remove(entityDriver);

            await _context.SaveChangesAsync(ct);

            return request.DriverId;
        }

        public async Task<DriverDTO> UpdateDriver(CreateUpdateDriverCommand request, CancellationToken ct)
        {

            var entityDriver = await _context.Drivers.FindAsync(new object[] { request.DriverId }, ct);

            if (entityDriver == null)
            {
                throw new KeyNotFoundException("Driver not found");
            }

            entityDriver.UpdateEntity(
                    firstName: request.FirstName,
                    lastName: request.LastName,
                    middleName: request.MiddleName,
                    suffix: request.Suffix,
                    licenseNo: request.LicenseNo,
                    birthDate: request.Birthdate ?? null,
                    licenseExpiry: request.LicenseExpiry ?? null
                );


            await _context.SaveChangesAsync(ct);

            return _mapper.Map<DriverDTO>(entityDriver);

        }
    
    }
}
