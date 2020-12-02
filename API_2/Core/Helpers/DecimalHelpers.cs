using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Helpers
{
    public static class DecimalHelpers
    {
        /// Adaptado de: https://stackoverflow.com/questions/3143657/truncate-two-decimal-places-without-rounding
        public static decimal Truncate(this decimal d, byte decimals)
        {
            decimal r = Math.Round(d, decimals);

            if (d > 0 && r > d)
            {
                return r - new decimal(1, 0, 0, false, decimals);
            }
            else if (d < 0 && r < d)
            {
                return r + new decimal(1, 0, 0, false, decimals);
            }

            return r;
        }
    }
}
