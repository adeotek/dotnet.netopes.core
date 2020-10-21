using Netopes.Core.Helpers.Email;

namespace Netopes.Core.App.Settings
{
    public interface IAppSettingsBase
    {
        bool Debug { get; set; }
        string DefaultCulture { get; set; }
        int RowsPerPage { get; set; }
        string DateFormat { get; set; }
        string TimeFormat { get; set; }
        string DecimalSeparator { get; set; }
        string GroupSeparator { get; set; }
        string AuthorizationIssuer { get; set; }
        string SecretKey { get; set; }
        ConnectionStrings ConnectionStrings { get; set; }
        EmailSettings EmailSettings { get; set; }
        string DateTimeFormat { get; }
        string GetNumberFormat(int decimals);
    }
}
