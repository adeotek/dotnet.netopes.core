using System.Collections.Generic;

namespace Netopes.Core.App.Settings
{
    public class NavigationHelper
    {
        public const string ChangeCultureUrl = "ChangeCultureUrl";
        public const string LoginUrl = "LoginUrl";
        public const string LoginRedirectUrl = "LoginRedirectUrl";
        public const string RegisterUrl = "RegisterUrl";
        public const string LogoutUrl = "LogoutUrl";
        public const string ManageAccountUrl = "ManageAccountUrl";
        
        private readonly Dictionary<string, string> _data = new Dictionary<string, string>();

        public string this[string property] => _data?[property];

        public string Get(string property, string defaultValue = null) => _data?[property] ?? defaultValue;

        public NavigationHelper Set(string property, string value)
        {
            if (!string.IsNullOrWhiteSpace(property))
            {
                _data[property] = value;
            }
            return this;
        }
    }
}