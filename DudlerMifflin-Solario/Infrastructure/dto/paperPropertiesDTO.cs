using Dapper;
using DudlerMifflin_Solario.Infrastructure.models;
using Npgsql;

namespace DudlerMifflin_Solario.Infrastructure.dto;

public class paperPropertiesDTO
{
    private readonly NpgsqlDataSource _dataSource;

    public PaperPropertiesDTO(NpgsqlDataSource dataSource)
    {
        _dataSource = dataSource;
    }

    public IEnumerable<paperProperties> getAllPaperProperties()
    {
        var sql = "SELECT * FROM paperProperties;";
        using (var conn = _dataSource.OpenConnection())
        {
            return conn.Query<paperProperties>(sql);
        }
    }

    public paperProperties createPaperProperty(int paperId, int propertyId)
    {
        var sql = @"
                INSERT INTO paperProperties (paper_id, property_id)
                VALUES (@PaperId, @PropertyId)
                RETURNING paper_id AS PaperId,
                          property_id AS PropertyId";

        using (var conn = _dataSource.OpenConnection())
        {
            return conn.QueryFirst<paperProperties>(sql, new { PaperId = paperId, PropertyId = propertyId });
        }
    }
    
    public paperProperties updatePaperProperty(int oldPaperId, int oldPropertyId, int newPaperId, int newPropertyId)
    {
        var sql = @"
                UPDATE paper_properties
                SET paper_id = @NewPaperId, property_id = @NewPropertyId
                WHERE paper_id = @OldPaperId AND property_id = @OldPropertyId
                RETURNING paper_id AS PaperId, property_id AS PropertyId";

        using (var conn = _dataSource.OpenConnection())
        {
            return conn.QueryFirst<paperProperties>(sql, new { OldPaperId = oldPaperId, OldPropertyId = oldPropertyId, NewPaperId = newPaperId, NewPropertyId = newPropertyId });
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

    public IEnumerable<paperProperties> getPropertiesByPaperId(int paperId)
    {
        var sql = "SELECT * FROM paperProperties WHERE paper_id = @PaperId;";
        using (var conn = _dataSource.OpenConnection())
        {
            return conn.Query<paperProperties>(sql, new { PaperId = paperId });
        }
    }
}