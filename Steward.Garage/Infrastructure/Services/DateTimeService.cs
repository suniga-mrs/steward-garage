using Steward.Garage.Application.Shared.Interfaces;

namespace Steward.Garage.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.UtcNow;
    }
}
