using Dapper;
using DudlerMifflin_Solario.Infrastructure.models;
using Npgsql;

namespace DudlerMifflin_Solario.Infrastructure.infra;

public class PaperPropertiesInfra
{
    private readonly NpgsqlDataSource _dataSource;

    public PaperPropertiesInfra(NpgsqlDataSource dataSource)
    {
        _dataSource = dataSource;
    }

    public IEnumerable<PaperProperties> getAllPaperProperties()
    {
        var sql = "SELECT * FROM paperProperties;";
        using (var conn = _dataSource.OpenConnection())
        {
            return conn.Query<PaperProperties>(sql);
        }
    }

    public PaperProperties createPaperProperty(int paperId, int propertyId)
    {
        var sql = @"
                INSERT INTO paperProperties (paper_id, property_id)
                VALUES (@PaperId, @PropertyId)
                RETURNING paper_id AS PaperId,
                          property_id AS PropertyId";

        using (var conn = _dataSource.OpenConnection())
        {
            return conn.QueryFirst<PaperProperties>(sql, new { PaperId = paperId, PropertyId = propertyId });
        }
    }
    
    public PaperProperties updatePaperProperty(int paperId, int propertyId)
    {
        var sql = @"
            UPDATE paper_properties
            SET paper_id = @PaperId, property_id = @PropertyId
            WHERE paper_id = @PaperId AND property_id = @PropertyId
            RETURNING paper_id AS PaperId, property_id AS PropertyId";

    using (var conn = _dataSource.OpenConnection())
    {
        return conn.QueryFirst<PaperProperties>(sql, new { PaperId = paperId, PropertyId = propertyId });
    }
    }

    public bool deletePaperProperty(int paperId, int propertyId)
    {
        var sql = "DELETE FROM paperProperties WHERE paper_id = @PaperId AND property_id = @PropertyId";
        using (var conn = _dataSource.OpenConnection())
        {
            return conn.Execute(sql, new { PaperId = paperId, PropertyId = propertyId }) == 1; 
        }
    }

    /*public IEnumerable<paperProperties> getPropertiesByPaperId(int paperId)
    {
        var sql = "SELECT * FROM paperProperties WHERE paper_id = @PaperId;";
        using (var conn = _dataSource.OpenConnection())
        {
            return conn.Query<paperProperties>(sql, new { PaperId = paperId });
        }
    }*/
}