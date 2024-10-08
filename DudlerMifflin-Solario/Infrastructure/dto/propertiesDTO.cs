using Dapper;
using DudlerMifflin_Solario.Infrastructure.models;
using Npgsql;

namespace DudlerMifflin_Solario.Infrastructure.dto;

public class propertiesDTO
{
    private readonly NpgsqlDataSource _dataSource;

        public PropertiesDTO(NpgsqlDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public IEnumerable<properties> getAllProperties()
        {
            var sql = "SELECT * FROM properties;";
            using (var conn = _dataSource.OpenConnection())
            {
                return conn.Query<properties>(sql);
            }
        }

        public properties createProperty(string propertyName)
        {
            var sql = @"
                INSERT INTO properties (property_name)
                VALUES (@PropertyName)
                RETURNING id AS Id,
                          property_name AS PropertyName";

            using (var conn = _dataSource.OpenConnection())
            {
                return conn.QueryFirst<properties>(sql, new { PropertyName = propertyName });
            }
        }

        public properties updateProperty(int id, string propertyName)
        {
            var sql = @"
                UPDATE properties
                SET property_name = @PropertyName
                WHERE id = @Id
                RETURNING id AS Id,
                          property_name AS PropertyName";

            using (var conn = _dataSource.OpenConnection())
            {
                return conn.QueryFirst<properties>(sql, new { Id = id, PropertyName = propertyName });
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

        public properties getPropertyById(int id)
        {
            var sql = "SELECT * FROM properties WHERE id = @Id";
            using (var conn = _dataSource.OpenConnection())
            {
                return conn.QueryFirstOrDefault<properties>(sql, new { Id = id });
            }
        }
}