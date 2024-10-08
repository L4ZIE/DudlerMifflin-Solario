using Dapper;
using DudlerMifflin_Solario.Infrastructure.models;
using Npgsql;

namespace DudlerMifflin_Solario.Infrastructure.dto;

public class ordersDTO
{
    private readonly NpgsqlDataSource _dataSource;

        public OrdersDTO(NpgsqlDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public IEnumerable<orders> getAllOrders()
        {
            var sql = "SELECT * FROM orders;";
            using (var conn = _dataSource.OpenConnection())
            {
                return conn.Query<orders>(sql);
            }
        }

        public orders createOrder(DateTimeOffset orderDate, DateTime deliveryDate, string status, double totalAmount, int customerId)
        {
            var sql = @"
                INSERT INTO orders (order_date, delivery_date, status, total_amount, customer_id)
                VALUES (@OrderDate, @DeliveryDate, @Status, @TotalAmount, @CustomerId)
                RETURNING id AS OrderId,
                          order_date AS OrderDate,
                          delivery_date AS DeliveryDate,
                          status AS Status,
                          total_amount AS TotalAmount,
                          customer_id AS CustomerId";

            using (var conn = _dataSource.OpenConnection())
            {
                return conn.QueryFirst<orders>(sql, new { OrderDate = orderDate, DeliveryDate = deliveryDate, Status = status, TotalAmount = totalAmount, CustomerId = customerId });
            }
        }

        public orders updateOrder(int orderId, DateTimeOffset orderDate, DateTime deliveryDate, string status, double totalAmount, int customerId)
        {
            var sql = @"
                UPDATE orders
                SET order_date = @OrderDate, delivery_date = @DeliveryDate, status = @Status, total_amount = @TotalAmount, customer_id = @CustomerId
                WHERE id = @OrderId
                RETURNING id AS OrderId,
                          order_date AS OrderDate,
                          delivery_date AS DeliveryDate,
                          status AS Status,
                          total_amount AS TotalAmount,
                          customer_id AS CustomerId";

            using (var conn = _dataSource.OpenConnection())
            {
                return conn.QueryFirst<orders>(sql, new { OrderId = orderId, OrderDate = orderDate, DeliveryDate = deliveryDate, Status = status, TotalAmount = totalAmount, CustomerId = customerId });
            }
        }

        public bool deleteOrder(int orderId)
        {
            var sql = "DELETE FROM orders WHERE id = @OrderId";
            using (var conn = _dataSource.OpenConnection())
            {
                return conn.Execute(sql, new { OrderId = orderId }) == 1; 
            }
        }

        public orders getOrderById(int orderId)
        {
            var sql = "SELECT * FROM orders WHERE id = @OrderId";
            using (var conn = _dataSource.OpenConnection())
            {
                return conn.QueryFirstOrDefault<orders>(sql, new { OrderId = orderId });
            }
        }
}