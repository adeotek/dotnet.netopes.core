using System;
using System.Globalization;
using Netopes.Core.Abstraction.Settings;

namespace Netopes.Core.App.Services
{
    public class ValueFormatProvider
    {
        private readonly IAppSettingsBase _appSettings;
        private readonly NumberFormatInfo _customNumberFormatInfo; 

        public ValueFormatProvider(IAppSettingsBase appSettings)
        {
            _appSettings = appSettings ?? throw new ArgumentNullException(nameof(appSettings));
            _customNumberFormatInfo = new NumberFormatInfo
            {
                NumberDecimalSeparator = _appSettings.DecimalSeparator,
                NumberGroupSeparator = _appSettings.GroupSeparator
            };
        }

        public string AsDate(object value, string defaultValue = null)
        {
            if (!(value is DateTime))
            {
                return defaultValue ?? string.Empty;
            }

            return ((DateTime) value).ToString(_appSettings.DateFormat);
        }
        
        public string AsTime(object value, string defaultValue = null)
        {
            if (!(value is DateTime))
            {
                return defaultValue ?? string.Empty;
            }

            return ((DateTime) value).ToString(_appSettings.TimeFormat);
        }
        
        public string AsDateTime(object value, string defaultValue = null)
        {
            if (!(value is DateTime))
            {
                return defaultValue ?? string.Empty;
            }

            return ((DateTime) value).ToString($"{_appSettings.DateFormat} {_appSettings.TimeFormat}");
        }

        public string AsDecimal(object value, int decimals, string defaultValue = null, bool defaultForZero = false)
        {
            var format = $"{{0:#,##0{(decimals > 0 ? $".{new string('0', decimals)}" : string.Empty)}}}";
            
            return value switch
            {
                decimal decimalValue => decimalValue == 0 && defaultForZero ? defaultValue : string.Format(_customNumberFormatInfo, format, value),
                double doubleValue => doubleValue == 0 && defaultForZero ? defaultValue : string.Format(_customNumberFormatInfo, format, value),
                _ => defaultValue ?? string.Empty
            };
        }
    }
}