using Npgsql;

namespace Np.PostgreSQL.DbConnectionFactory
{
    /// <summary>
    /// Connection factory for <see cref="NpgsqlConnection"/>
    /// </summary>
    public interface IDbConnectionFactory
    {
        /// <summary>
        /// Get connection
        /// </summary>
        /// <returns>NpgsqlConnection</returns>
        NpgsqlConnection GetConnection();
    }
}