using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Steward.Garage.Application.Shared.Models
{
    public abstract class BaseAuditableEntity 
    {

        public DateTime DateCreated { get; set; } = DateTime.MinValue;

        public string CreatedBy { get; set; } = string.Empty;

        public DateTime DateLastModified { get; set; } = DateTime.MinValue;

        public string LastModifiedBy { get; set; } = string.Empty;

        public DateTime DateDeleted { get; set; } = DateTime.MinValue;

        public string DeletedBy { get; set; } = string.Empty;

        public bool IsDeleted { get; set; } = false;

    }
 
}
