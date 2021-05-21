using System;
using System.Collections.Generic;

namespace Cognitic.Tools.Connections.Database
{
    public class Command
    {
        internal string Query { get; private set; }
        internal bool IsStoredProcedure { get; private set; }
        internal Dictionary<string, object> Parameters { get; private set; }

        public Command(string query)
        {
            if(string.IsNullOrWhiteSpace(query))
            {
                throw new ArgumentException(nameof(query));
            }

            Query = query;
            Parameters = new Dictionary<string, object>();
        }

        public Command(string query, bool isStoredProcedure)
            : this(query)
        {
            IsStoredProcedure = isStoredProcedure;
        }

        public void AddParameters(string parameterName, object value)
        {
            Parameters.Add(parameterName, value ?? DBNull.Value);
        }
    }
}
