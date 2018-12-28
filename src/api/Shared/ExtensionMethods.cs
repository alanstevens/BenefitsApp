using System;

namespace BenefitsApp.API.Shared
{
    public static class ExtensionMethods
    {
        public static string ToCurrencyString(this decimal value)
        {
            // Bankers rounding (IEEE 754 section 4)
            return decimal.Round(value, 2, MidpointRounding.ToEven).ToString("C");
        }

        public static bool IsBlank(this string value) => string.IsNullOrWhiteSpace(value);

        public static bool IsNull(this object value) => ReferenceEquals(value, null);
    }
}
