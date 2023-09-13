using Npgsql;

namespace Np.PostgreSQL.DbConnectionFactory
{
    /// <inheritdoc />
    public class DbConnectionFactory : IDbConnectionFactory
    {
        private readonly string _connectionString;

        /// <param name="connectionString">Connection string</param>
        public DbConnectionFactory(string connectionString) => _connectionString = connectionString;

        /// <inheritdoc />
        public NpgsqlConnection GetConnection() => new NpgsqlConnection(_connectionString);
    }
}
