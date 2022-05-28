namespace Steward.WheelBox.Application.Shared.Models
{
    public abstract class BaseSoftDeleteEntity 
    {
        public DateTime DateDeleted { get; set; } = DateTime.MinValue;
        public string? DeletedBy { get; set; } = string.Empty;
        public bool IsDeleted { get; set; } = false;

    }

}
