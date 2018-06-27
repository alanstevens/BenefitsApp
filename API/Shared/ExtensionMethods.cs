using System;

namespace Paylocity.Benefits.Service.Shared
{
    public static class ExtensionMethods
    {
        public static string ToCurrency(this decimal value)
        {
            // Bankers rounding (IEEE 754 section 4)
            return decimal.Round(value, 2, MidpointRounding.ToEven).ToString("C");
        }
        
    }
}