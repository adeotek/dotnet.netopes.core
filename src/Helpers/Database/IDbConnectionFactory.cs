using System.Data;

namespace Netopes.Core.Helpers.Database
{
    /// <summary>
    ///     A factory for creating instances of <see cref="IDbConnection" />.
    /// </summary>
    public interface IDbConnectionFactory
    {
        /// <summary>
        ///     The connection string to use for connecting to SQL Server.
        /// </summary>
        string ConnectionString { get; set; }

        /// <summary>
        ///     Database objects names escape character.
        /// </summary>
        string DbObjectsEscapeChar { get; set; }

        /// <summary>
        ///     Database objects names prefix (null or empty for no pefix).
        /// </summary>
        string DbObjectsPrefix { get; set; }

        /// <summary>
        ///     Database schema name (null for default for no schema).
        /// </summary>
        string DbSchema { get; set; }

        /// <summary>
        ///     Database GUIDs fields values converter (null or empty for none).
        /// </summary>
        string GuidConverter { get; set; }

        /// <summary>
        ///     Creates a new instance of the underlying <see cref="IDbConnection" />.
        /// </summary>
        IDbConnection Create();
    }
}