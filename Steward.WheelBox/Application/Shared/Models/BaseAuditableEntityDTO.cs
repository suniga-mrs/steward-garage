namespace Steward.WheelBox.Application.Shared.Models
{
    public class BaseAuditableEntityDTO
    {
        public DateTime DateCreated { get; set; } = DateTime.MinValue;
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime DateLastModified { get; set; } = DateTime.MinValue;
        public string LastModifiedBy { get; set; } = string.Empty;
    }
}
