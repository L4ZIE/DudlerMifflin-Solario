using Dapper;
using DudlerMifflin_Solario.Infrastructure.models;
using Npgsql;

namespace DudlerMifflin_Solario.Infrastructure.infra;

public class CustomersInfra
{
    private readonly NpgsqlDataSource _dataSource;

        public CustomersInfra(NpgsqlDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public IEnumerable<Customers> getAllCustomers()
        {
            var sql = "SELECT * FROM customers;";
            using (var conn = _dataSource.OpenConnection())
            {
                return conn.Query<Customers>(sql);
            }
        }

        public Customers createCustomer(string customerName, string address, string phone, string email)
        {
            var sql = @"
                INSERT INTO customers (name, address, phone, email)
                VALUES (@CustomerName, @Address, @Phone, @Email)
                RETURNING id AS CustomerId,
                          name AS CustomerName,
                          address AS Address,
                          phone AS Phone,
                          email AS Email";

            using (var conn = _dataSource.OpenConnection())
            {
                return conn.QueryFirst<Customers>(sql, new { CustomerName = customerName, Address = address, Phone = phone, Email = email });
            }
        }

        public Customers updateCustomer(int customerId, string customerName, string address, string phone, string email)
        {
            var sql = @"
                UPDATE customers
                SET name = @CustomerName, address = @Address, phone = @Phone, email = @Email
                WHERE id = @CustomerId
                RETURNING id AS CustomerId,
                          name AS CustomerName,
                          address AS Address,
                          phone AS Phone,
                          email AS Email";

            using (var conn = _dataSource.OpenConnection())
            {
                return conn.QueryFirst<Customers>(sql, new { CustomerId = customerId, CustomerName = customerName, Address = address, Phone = phone, Email = email });
            }
        }

        public bool deleteCustomer(int customerId)
        {
            var sql = "DELETE FROM customers WHERE id = @CustomerId";
            using (var conn = _dataSource.OpenConnection())
            {
                return conn.Execute(sql, new { CustomerId = customerId }) == 1;
            }
        }
}