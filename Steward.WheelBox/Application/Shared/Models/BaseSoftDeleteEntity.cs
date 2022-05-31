using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Steward.WheelBox.Application.Shared.Models
{
    public abstract class BaseSoftDeleteEntity 
    {

        [Column("datedeleted")]
        public DateTime DateDeleted { get; set; } = DateTime.MinValue;

        [Column("deletedby")]
        [MaxLength(500)]
        public string DeletedBy { get; set; } = string.Empty;

        [Column("isdeleted")]
        public bool IsDeleted { get; set; } = false;

    }

}
