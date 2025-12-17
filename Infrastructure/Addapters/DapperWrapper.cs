using System.ComponentModel;
using System.Data;
using System.Globalization;
using Coink.Microservice.Ports;
using Dapper;

namespace Coink.Microservice.Infrastructure.Addapters
{
    public class DapperWrapper : IQueryWrapper
    {
        private readonly IDbConnection _connection;
        private readonly ComponentResourceManager _componentResourceManager;

        public DapperWrapper(IDbConnection connection)
            : this(connection, typeof(Constants.SqlQueries))
        {
        }

        public DapperWrapper(IDbConnection connection, Type resourceType)
        {
            _connection = connection;
            _componentResourceManager = new ComponentResourceManager(resourceType);
        }

        public async Task ExecuteAsync(string resourceItemDescription, object parameters)
        {
            string query = GetQuery(resourceItemDescription);

            await _connection.ExecuteAsync(query, parameters);
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string resourceItemDescription, object? parameters = null)
        {
            string query = GetQuery(resourceItemDescription);

            return await _connection.QueryAsync<T>(query, parameters);
        }

        public async Task<T?> QueryFirstOrDefaultAsync<T>(string resourceItemDescription, object? parameters = null)
        {
            string query = GetQuery(resourceItemDescription);

            return await _connection.QueryFirstOrDefaultAsync<T>(query, parameters);
        }

        public async Task<T> QuerySingleAsync<T>(string resourceItemDescription, object? parameters = null)
        {
            string query = GetQuery(resourceItemDescription);

            return await _connection.QuerySingleAsync<T>(query, parameters);
        }

        private string GetQuery(string resourceItemDescription, object[]? args = null)
        {
            if (args is null)
            {
                return string.Format(
                    CultureInfo.InvariantCulture,
                    _componentResourceManager.GetString(resourceItemDescription)!
                );
            }

            return string.Format(
                CultureInfo.InvariantCulture,
                _componentResourceManager.GetString(resourceItemDescription)!,
                args!
            );
        }
    }
}
