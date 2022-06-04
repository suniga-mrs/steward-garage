using FluentValidation;
using MediatR;
using Steward.WheelBox.Application.Modules.DataReferences.DTO;
using Steward.WheelBox.Application.Modules.DataReferences.Interfaces;
using Steward.WheelBox.Application.Shared.Interfaces;

namespace Steward.WheelBox.Application.Modules.DataReferences.CommandQuery
{
    public class CreateUpdateUnitCommand : IRequest<UnitDTO>
    {
        public int UnitId { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public string Prefix { get; set; } = string.Empty;
        public string Suffix { get; set; } = string.Empty;
    }

    public class CreateUpdateUnitCommandValidator : AbstractValidator<CreateUpdateUnitCommand>
    {

        public CreateUpdateUnitCommandValidator()
        {

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required")
                .MaximumLength(50).WithMessage("First Name exceeds max length of 50.");               

        }

    }

    public class CreateUpdateUnitCommandHandler : IRequestHandler<CreateUpdateUnitCommand, UnitDTO>
    {

        private IApplicationDbContext _context;
        private IUnitService _unitService;

        public CreateUpdateUnitCommandHandler(IApplicationDbContext context, IUnitService driverService)
        {
            _context = context;
            _unitService = driverService;
        }

        public async Task<UnitDTO> Handle(CreateUpdateUnitCommand request, CancellationToken cancellationToken)
        {
            await using var tx = await _context.Database.BeginTransactionAsync();

            try
            {
                UnitDTO unit;

                if (request.UnitId != 0)
                {
                    unit = await _unitService.UpdateUnit(request, cancellationToken);
                }
                else
                {
                    unit = await _unitService.CreateUnit(request, cancellationToken);
                }

                await tx.CommitAsync();

                return unit;

            }
            catch
            {
                await tx.RollbackAsync();
                throw;
            }
        }
    }
}
