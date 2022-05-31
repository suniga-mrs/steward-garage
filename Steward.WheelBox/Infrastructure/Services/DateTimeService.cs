using Steward.WheelBox.Application.Shared.Interfaces;

namespace Steward.WheelBox.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.UtcNow;
    }
}
