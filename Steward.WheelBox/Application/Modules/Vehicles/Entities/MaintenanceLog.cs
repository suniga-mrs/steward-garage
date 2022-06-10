using Steward.WheelBox.Application.Modules.BusinessProviders.Entities;
using Steward.WheelBox.Application.Shared.Models;

namespace Steward.WheelBox.Application.Modules.Vehicles.Entities
{
    public class MaintenanceLog : BaseAuditableEntity
    {
        public int MaintenanceLogId { get; }
        public decimal TotalAmount { get; set; }
        public int TotalAmountUnitId { get; set; }
        public string Remarks { get; set; } = string.Empty;
        public int ServiceById { get; set; }
        public int VehicleId { get; set; }
        public int OdometerId { get; set; }
        public DateTime? LogDate { get; set; } = DateTime.MinValue;


        public virtual Odometer Odometer { get; set; } = null!;
        public virtual BusinessProvider ServiceBy { get; set; } = null!;
        public virtual Vehicle Vehicle { get; set; } = null!;


        public MaintenanceLog(decimal totalAmount, int totalAmountUnitId, string remarks, int serviceById, int vehicleId, int odometerId, DateTime? logDate)
        {
            AssignValues(totalAmount, totalAmountUnitId, remarks, serviceById, vehicleId, odometerId, logDate);

        }
        private void AssignValues(decimal totalAmount = 0, int totalAmountUnitId = 0, string remarks = "", int serviceById = 0, int vehicleId = 0, int odometerId = 0, DateTime? logDate = null)
        {
            TotalAmount = totalAmount;
            TotalAmountUnitId = totalAmountUnitId;
            Remarks = remarks;
            ServiceById = serviceById;
            VehicleId = vehicleId;
            OdometerId = odometerId;
            LogDate = logDate;
        }


        public void UpdateEntity(decimal totalAmount, int totalAmountUnitId, string remarks, int serviceById, int vehicleId, int odometerId, DateTime? logDate)
        {
            AssignValues(totalAmount, totalAmountUnitId, remarks, serviceById, vehicleId, odometerId, logDate);

        }
    }
}
