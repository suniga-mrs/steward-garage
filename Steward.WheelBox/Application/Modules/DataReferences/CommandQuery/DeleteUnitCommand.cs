using FluentValidation;
using MediatR;
using Steward.WheelBox.Application.Modules.DataReferences.Interfaces;
using Steward.WheelBox.Application.Shared.Interfaces;

namespace Steward.WheelBox.Application.Modules.DataReferences.CommandQuery
{
    public class DeleteUnitCommand : IRequest<int>
    {
        public int UnitId { get; set; }
    }


    public class DeleteUnitCommandValidator : AbstractValidator<DeleteUnitCommand>
    {
        public DeleteUnitCommandValidator()
        {
            RuleFor(x => x.UnitId)
                .NotEmpty().WithMessage("Unique identifier required.");
        }

    }


    public class DeleteUnitCommandHandler : IRequestHandler<DeleteUnitCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IUnitService _unitService;
        public DeleteUnitCommandHandler(IApplicationDbContext context, IUnitService unitService)
        {
            _context = context;
            _unitService = unitService;
        }

        public async Task<int> Handle(DeleteUnitCommand request, CancellationToken cancellationToken)
        {
            await using var tx = await _context.Database.BeginTransactionAsync();

            try
            {
                await _unitService.DeleteUnit(request, cancellationToken);

                await tx.CommitAsync();

                return request.UnitId;

            }
            catch (Exception e)
            {
                await tx.RollbackAsync();
                throw;
            }
        }
    }
}
