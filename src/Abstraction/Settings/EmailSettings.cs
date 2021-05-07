namespace Netopes.Core.Abstraction.Settings
{
    public class EmailSettings
    {
        public string Server { get; set; }
        public int Port { get; set; }
        public string Label { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Ssl { get; set; }
    }
}
