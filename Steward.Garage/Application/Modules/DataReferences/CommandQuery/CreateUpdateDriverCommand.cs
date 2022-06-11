using FluentValidation;
using MediatR;
using Steward.Garage.Application.Modules.DataReferences.DTO;
using Steward.Garage.Application.Modules.DataReferences.Interfaces;
using Steward.Garage.Application.Shared.Interfaces;

namespace Steward.Garage.Application.Modules.DataReferences.CommandQuery
{
    public class CreateUpdateDriverCommand : IRequest<DriverDTO>
    {
        public int DriverId { get; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string Suffix { get; set; } = string.Empty;
        public string LicenseNo { get; set; } = string.Empty;
        public DateTime? Birthdate { get; set; }
        public DateTime? LicenseExpiry { get; set; }
    }

    public class CreateUpdateDriverCommandValidator : AbstractValidator<CreateUpdateDriverCommand>
    {

        public CreateUpdateDriverCommandValidator()
        {

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First Name is required");
            RuleFor(x => x.FirstName)
                .MaximumLength(50).WithMessage("First Name exceeds max length of 50.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last Name is required");
            RuleFor(x => x.LastName)
               .MaximumLength(50).WithMessage("Last Name exceeds max length of 50.");

            RuleFor(x => x.MiddleName)
              .MaximumLength(50).WithMessage("Middle Name exceeds max length of 50.");

            RuleFor(x => x.Suffix)
              .MaximumLength(10).WithMessage("Suffix Name exceeds max length of 10.");

            RuleFor(x => x.LicenseNo)
              .MaximumLength(30).WithMessage("License No. exceeds max length of 30.");

        }

    }

    public class CreateUpdateDriverCommandHandler : IRequestHandler<CreateUpdateDriverCommand, DriverDTO>
    {
        private IApplicationDbContext _context;
        private IDriverService _driverService;
        public CreateUpdateDriverCommandHandler(IApplicationDbContext context, IDriverService driverService)
        {
            _context = context;
            _driverService = driverService;
        }

        public async Task<DriverDTO> Handle(CreateUpdateDriverCommand request, CancellationToken cancellationToken)
        {
            await using var tx = await _context.Database.BeginTransactionAsync();

            try
            {
                DriverDTO driver;

                if(request.DriverId != 0)
                {
                    driver = await _driverService.UpdateDriver(request, cancellationToken);
                }
                else
                {
                    driver = await _driverService.CreateDriver(request, cancellationToken);
                }

                await tx.CommitAsync();

                return driver;

            }
            catch
            {
                await tx.RollbackAsync();
                throw;
            }

        }
    }
}
