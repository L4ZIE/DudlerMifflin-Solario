using DudlerMifflin_Solario.Infrastructure.infra;
using DudlerMifflin_Solario.Infrastructure.models;

namespace DudlerMifflin_Solario.service;

public class CustomersService
{
    private readonly CustomersInfra _customersInfra;

    public CustomersService(CustomersInfra customersInfra)
    {
        _customersInfra = customersInfra;
    }

    public IEnumerable<Customers> getAllCustomers()
    {
        return _customersInfra.getAllCustomers();
    }

    public Customers createCustomer(string customerName, string address, string phone, string email)
    {
        return _customersInfra.createCustomer(customerName, address, phone, email);
    }

    public Customers updateCustomer(int customerId, string customerName, string address, string phone, string email)
    {
        return _customersInfra.updateCustomer(customerId, customerName, address, phone, email);
    }

    public bool deleteCustomer(int customerId)
    {
        return _customersInfra.deleteCustomer(customerId);
    }
}