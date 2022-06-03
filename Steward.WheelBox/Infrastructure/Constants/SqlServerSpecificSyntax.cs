namespace Steward.WheelBox.Infrastructure.Constants
{
    public class SqlServerSpecificSyntax
    {
        public const string UniqueId = "NEWID()";
        public static string DecimalColumn(int maxDigits = 18, int decimalPlaces = 2) => $"decimal({maxDigits},{decimalPlaces})";
    }
}
