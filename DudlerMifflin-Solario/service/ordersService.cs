using DudlerMifflin_Solario.Infrastructure.dto;
using DudlerMifflin_Solario.Infrastructure.models;

namespace DudlerMifflin_Solario.service;

public class ordersService
{
    private readonly ordersDTO _ordersDto;

    public ordersService(ordersDTO ordersDto)
    {
        _ordersDto = ordersDto;
    }

    public IEnumerable<orders> getAllOrders()
    {
        return _ordersDto.getAllOrders();
    }

    public orders createOrder(DateTimeOffset orderDate, DateTime deliveryDate, string status, double totalAmount, int customerId)
    {
        return _ordersDto.createOrder(orderDate, deliveryDate, status, totalAmount, customerId);
    }

    public orders updateOrder(int orderId, DateTimeOffset orderDate, DateTime deliveryDate, string status, double totalAmount, int customerId)
    {
        return _ordersDto.updateOrder(orderId, orderDate, deliveryDate, status, totalAmount, customerId);
    }

    public bool deleteOrder(int orderId)
    {
        return _ordersDto.deleteOrder(orderId);
    }

    public orders getOrderById(int orderId)
    {
        return _ordersDto.getOrderById(orderId);
    }
}