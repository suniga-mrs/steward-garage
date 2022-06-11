namespace Steward.Garage.Infrastructure.Constants
{
    public class SqlServerSpecificSyntax
    {
        public static string UniqueId = "NEWID()";
        public static DateTime DefaultDateTime = DateTime.MinValue;
        public static string DecimalColumn(int maxDigits = 18, int decimalPlaces = 2) => $"decimal({maxDigits},{decimalPlaces})";
    }
}
