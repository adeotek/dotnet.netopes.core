using Netopes.Core.Helpers.Email;

namespace Netopes.Core.App.Settings
{
    public class AppSettingsBase : IAppSettingsBase
    {
        public bool Debug { get; set; }
        public string DefaultCulture { get; set; }
        public int RowsPerPage { get; set; }
        public string DateFormat { get; set; }
        public string TimeFormat { get; set; }
        public string DecimalSeparator { get; set; }
        public string GroupSeparator { get; set; }
        public string AuthorizationIssuer { get; set; }
        public string SecretKey { get; set; }
        public ConnectionStrings ConnectionStrings { get; set; }
        public EmailSettings EmailSettings { get; set; }
        public string DateTimeFormat => $"{DateFormat} {TimeFormat}";

        public string GetNumberFormat(int decimals) => decimals > 0
            ? $"#{GroupSeparator}##0{DecimalSeparator}{new string ('0', decimals)}"
            : $"#{GroupSeparator}##0";
    }
}
