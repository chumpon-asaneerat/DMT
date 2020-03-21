#region Using

using System;
using System.Globalization;

#endregion

namespace DMT
{
    #region DateTime Extension Methods

    /// <summary>
    /// The DateTime Extension Methods.
    /// </summary>
    public static class DateTimeExtension
    {
        /// <summary>
        /// To Date String.
        /// </summary>
        /// <param name="value">The DateTime instance.</param>
        /// <returns>Returns string that represents date part.</returns>
        public static string ToDateString(this DateTime value)
        {
            if (value == DateTime.MinValue || value == DateTime.MaxValue)
                return "";
            return value.ToString("yyyy/MM/dd", DateTimeFormatInfo.InvariantInfo);
        }
        /// <summary>
        /// To Time String.
        /// </summary>
        /// <param name="value">The DateTime instance.</param>
        /// <returns>Returns string that represents time part.</returns>
        public static string ToTimeString(this DateTime value)
        {
            if (value == DateTime.MinValue || value == DateTime.MaxValue)
                return "";
            return value.ToString("HH:mm:ss.fff", DateTimeFormatInfo.InvariantInfo);
        }
        /// <summary>
        /// To DateTime String.
        /// </summary>
        /// <param name="value">The DateTime instance.</param>
        /// <returns>Returns string that represents datetime part.</returns>
        public static string ToDateTimeString(this DateTime value)
        {
            if (value == DateTime.MinValue || value == DateTime.MaxValue)
                return "";
            return value.ToString("yyyy/MM/dd HH:mm:ss.fff", DateTimeFormatInfo.InvariantInfo);
        }
    }

    #endregion
}
