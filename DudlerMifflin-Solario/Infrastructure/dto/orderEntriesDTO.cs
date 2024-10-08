using Dapper;
using DudlerMifflin_Solario.Infrastructure.models;
using Npgsql;

namespace DudlerMifflin_Solario.Infrastructure.dto;

public class orderEntriesDTO
{
    private readonly NpgsqlDataSource _dataSource;

    public OrderEntriesDTO(NpgsqlDataSource dataSource)
    {
        _dataSource = dataSource;
    }

    public IEnumerable<orderEntries> getAllOrderEntries()
    {
        var sql = "SELECT * FROM order_entries;";
        using (var conn = _dataSource.OpenConnection())
        {
            return conn.Query<orderEntries>(sql);
        }
    }

    public orderEntries createOrderEntry(int quantity, int productId, int orderId)
    {
        var sql = @"
                INSERT INTO order_entries (quantity, product_id, order_id)
                VALUES (@Quantity, @ProductId, @OrderId)
                RETURNING id AS Id,
                          quantity AS Quantity,
                          product_id AS ProductId,
                          order_id AS OrderId";

        using (var conn = _dataSource.OpenConnection())
        {
            return conn.QueryFirst<orderEntries>(sql, new { Quantity = quantity, ProductId = productId, OrderId = orderId });
        }
    }
    
    public orderEntries updateOrderEntry(int id, int quantity, int productId, int orderId)
    {
        var sql = @"
                UPDATE order_entries
                SET quantity = @Quantity, product_id = @ProductId, order_id = @OrderId
                WHERE id = @Id
                RETURNING id AS Id, quantity AS Quantity, product_id AS ProductId, order_id AS OrderId";

        using (var conn = _dataSource.OpenConnection())
        {
            return conn.QueryFirst<orderEntries>(sql, new { Id = id, Quantity = quantity, ProductId = productId, OrderId = orderId });
        }
    }

    public bool deleteOrderEntry(int id)
    {
        var sql = "DELETE FROM order_entries WHERE id = @Id";
        using (var conn = _dataSource.OpenConnection())
        {
            return conn.Execute(sql, new { Id = id }) == 1; 
        }
    }

    public IEnumerable<orderEntries> getOrderEntriesByOrderId(int orderId)
    {
        var sql = "SELECT * FROM order_entries WHERE order_id = @OrderId;";
        using (var conn = _dataSource.OpenConnection())
        {
            return conn.Query<orderEntries>(sql, new { OrderId = orderId });
        }
    }
}