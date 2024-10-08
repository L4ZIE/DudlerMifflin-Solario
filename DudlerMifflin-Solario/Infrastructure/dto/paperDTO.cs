using Dapper;
using DudlerMifflin_Solario.Infrastructure.models;
using Npgsql;

namespace DudlerMifflin_Solario.Infrastructure.dto;

public class paperDTO
{
    private readonly NpgsqlDataSource _dataSource;

        public PaperDTO(NpgsqlDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public IEnumerable<paper> getAllPapers()
        {
            var sql = "SELECT * FROM paper;";
            using (var conn = _dataSource.OpenConnection())
            {
                return conn.Query<paper>(sql);
            }
        }

        public paper createPaper(string paperName, bool discontinued, int stock, double price)
        {
            var sql = @"
                INSERT INTO paper (name, discontinued, stock, price)
                VALUES (@PaperName, @Discontinued, @Stock, @Price)
                RETURNING id AS PaperId,
                          name AS PaperName,
                          discontinued AS Discontinued,
                          stock AS Stock,
                          price AS Price";

            using (var conn = _dataSource.OpenConnection())
            {
                return conn.QueryFirst<paper>(sql, new { PaperName = paperName, Discontinued = discontinued, Stock = stock, Price = price });
            }
        }

        public paper updatePaper(int paperId, string paperName, bool discontinued, int stock, double price)
        {
            var sql = @"
                UPDATE paper
                SET name = @PaperName, discontinued = @Discontinued, stock = @Stock, price = @Price
                WHERE id = @PaperId
                RETURNING id AS PaperId,
                          name AS PaperName,
                          discontinued AS Discontinued,
                          stock AS Stock,
                          price AS Price";

            using (var conn = _dataSource.OpenConnection())
            {
                return conn.QueryFirst<paper>(sql, new { PaperId = paperId, PaperName = paperName, Discontinued = discontinued, Stock = stock, Price = price });
            }
        }

        public bool deletePaper(int paperId)
        {
            var sql = "DELETE FROM paper WHERE id = @PaperId";
            using (var conn = _dataSource.OpenConnection())
            {
                return conn.Execute(sql, new { PaperId = paperId }) == 1; 
            }
        }

        public paper getPaperById(int paperId)
        {
            var sql = "SELECT * FROM paper WHERE id = @PaperId";
            using (var conn = _dataSource.OpenConnection())
            {
                return conn.QueryFirstOrDefault<paper>(sql, new { PaperId = paperId });
            }
        }
}