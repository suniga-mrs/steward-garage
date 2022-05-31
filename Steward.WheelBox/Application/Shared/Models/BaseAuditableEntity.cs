using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Steward.WheelBox.Application.Shared.Models
{
    public abstract class BaseAuditableEntity : BaseSoftDeleteEntity
    {

        [Column("datecreated")]
        public DateTime DateCreated { get; set; } = DateTime.MinValue;

        [Column("createdby")]
        [MaxLength(500)]
        public string CreatedBy { get; set; } = string.Empty;

        [Column("datelastmodified")]
        public DateTime DateLastModified { get; set; } = DateTime.MinValue;

        [Column("lastmodifiedby")]
        [MaxLength(500)]
        public string LastModifiedBy { get; set; } = string.Empty;

    }


   
}
