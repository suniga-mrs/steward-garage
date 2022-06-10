using Steward.WheelBox.Application.Modules.DataReferences.Entities;
using Steward.WheelBox.Application.Shared.Models;

namespace Steward.WheelBox.Application.Modules.Vehicles.Entities
{
    public class Odometer : BaseAuditableEntity
    {
        public int OdometerId { get; }
        public DateTime? DateRead { get; set; } = DateTime.MinValue;
        public decimal Reading { get; set; } 
        public int VehicleId { get; set; }        
        public int ReadingUnitId { get; set; }
        public int GasLogId { get; set; }
        public int MaintenanceLogId { get; set; }


        public virtual Vehicle Vehicle { get; set; } = null!;
        public virtual Unit ReadingUnit { get; set; } = null!;
        public virtual GasLog GasLog { get; set; } = null!;
        public virtual MaintenanceLog MaintenanceLog { get; set; } = null!;


        public Odometer(DateTime? dateRead = null, decimal reading = 0.0m, int vehicleId = 0, int readingUnitId = 0, int gasLogId = 0, int maintenanceLogId = 0)
        {
            AssignValues(dateRead, reading, vehicleId, readingUnitId, gasLogId, maintenanceLogId);
        }

        private void AssignValues(DateTime? dateRead = null, decimal reading = 0.0m, int vehicleId = 0, int readingUnitId = 0, int gasLogId = 0, int maintenanceLogId = 0)
        {
            DateRead = dateRead;
            Reading = reading;
            VehicleId = vehicleId;
            ReadingUnitId = readingUnitId;
            GasLogId = gasLogId;
            MaintenanceLogId = maintenanceLogId;
        }

        public void UpdateEntity(DateTime? dateRead = null, decimal reading = 0.0m, int vehicleId = 0, int readingUnitId = 0, int gasLogId = 0, int maintenanceLogId = 0)
        {
            AssignValues(dateRead, reading, vehicleId, readingUnitId, gasLogId, maintenanceLogId);
        }

    }


}
