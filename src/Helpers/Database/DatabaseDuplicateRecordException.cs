using System;
using System.Collections.Generic;

namespace Netopes.Core.Helpers.Database
{
    public class DatabaseDuplicateRecordException : Exception
    {
        public IEnumerable<string> KeyFields { get; private set; }

        public DatabaseDuplicateRecordException(string message, IEnumerable<string> keyFields) : base(message)
        {
            KeyFields = keyFields;
        }
    }
}
