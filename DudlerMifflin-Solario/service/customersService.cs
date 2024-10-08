using DudlerMifflin_Solario.Infrastructure.dto;
using DudlerMifflin_Solario.Infrastructure.models;

namespace DudlerMifflin_Solario.service;

public class customersService
{
    private readonly customersDTO _customersDto;

    public customersService(customersDTO customersDto)
    {
        _customersDto = customersDto;
    }

    public IEnumerable<customers> getAllCustomers()
    {
        return _customersDto.getAllCustomers();
    }

    public customers createCustomer(string customerName, string address, string phone, string email)
    {
        return _customersDto.createCustomer(customerName, address, phone, email);
    }

    public customers updateCustomer(int customerId, string customerName, string address, string phone, string email)
    {
        return _customersDto.updateCustomer(customerId, customerName, address, phone, email);
    }

    public bool deleteCustomer(int customerId)
    {
        return _customersDto.deleteCustomer(customerId);
    }
}