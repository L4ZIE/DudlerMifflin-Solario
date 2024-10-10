using Dapper;
using DudlerMifflin_Solario.Infrastructure.models;
using Npgsql;

namespace DudlerMifflin_Solario.Infrastructure.infra;

public class PropertiesInfra
{
    private readonly NpgsqlDataSource _dataSource;

        public PropertiesInfra(NpgsqlDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public IEnumerable<Properties> getAllProperties()
        {
            var sql = "SELECT * FROM properties;";
            using (var conn = _dataSource.OpenConnection())
            {
                return conn.Query<Properties>(sql);
            }
        }

        public Properties createProperty(string propertyName)
        {
            var sql = @"
                INSERT INTO properties (property_name)
                VALUES (@PropertyName)
                RETURNING id AS Id,
                          property_name AS PropertyName";

            using (var conn = _dataSource.OpenConnection())
            {
                return conn.QueryFirst<Properties>(sql, new { PropertyName = propertyName });
            }
        }

        public Properties updateProperty(int id, string propertyName)
        {
            var sql = @"
                UPDATE properties
                SET property_name = @PropertyName
                WHERE id = @Id
                RETURNING id AS Id,
                          property_name AS PropertyName";

            using (var conn = _dataSource.OpenConnection())
            {
                return conn.QueryFirst<Properties>(sql, new { Id = id, PropertyName = propertyName });
            }
        }

        public bool deleteProperty(int id)
        {
            var sql = "DELETE FROM properties WHERE id = @Id";
            using (var conn = _dataSource.OpenConnection())
            {
                return conn.Execute(sql, new { Id = id }) == 1; 
            }
        }

        /*public properties getPropertyById(int id)
        {
            var sql = "SELECT * FROM properties WHERE id = @Id";
            using (var conn = _dataSource.OpenConnection())
            {
                return conn.QueryFirstOrDefault<properties>(sql, new { Id = id });
            }
        }*/
}