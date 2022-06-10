using Steward.WheelBox.Application.Shared.Models;

namespace Steward.WheelBox.Application.Modules.BusinessProviders.Entities
{
    public class BusinessProvider : BaseAuditableEntity
    {
        public int ProviderId { get; }
        public string ProviderName { get; set; } = string.Empty;
        // Address
        // Google Location
        // Type - supplier, maintenance | Business Type


        public BusinessProvider(string providerName)
        {
            AssignValues(providerName);
        }

        private void AssignValues(string providerName = "")
        {
            ProviderName = providerName;
        }

        public void UpdateEntity(string providerName)
        {
            AssignValues(providerName);
        }
    }

}
