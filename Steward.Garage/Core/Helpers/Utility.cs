namespace Steward.Garage.Core.Helpers
{
    public static class Utility
    {

        public static string NormalizeValue(string value)
        {
            return value.Trim().ToUpper();
        }

        public static DateTime TryParse(this DateTime? dateTime)
        {
            if (dateTime.HasValue)
            {
                return dateTime.GetValueOrDefault();
            }
            else
            {
                return DateTime.MinValue;
            }
        }

    }
}
