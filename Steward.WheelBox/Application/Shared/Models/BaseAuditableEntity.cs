namespace Steward.WheelBox.Application.Shared.Models
{
    public abstract class BaseAuditableEntity : BaseSoftDeleteEntity
    {
        public DateTime DateCreated { get; set; } = DateTime.MinValue;
        public string? CreatedBy { get; set; }
        public DateTime DateLastModified { get; set; } = DateTime.MinValue;
        public string? LastModifiedBy { get; set; }

    }


   
}
