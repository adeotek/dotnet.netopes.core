using System;

namespace Netopes.Core.Helpers.Database
{
    public class RecordInUseException : Exception
    {
        public RecordInUseException(string message) : base(message)
        {
        }
    }
}
