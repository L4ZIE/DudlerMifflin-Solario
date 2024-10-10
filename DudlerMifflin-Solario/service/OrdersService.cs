using DudlerMifflin_Solario.Infrastructure.infra;
using DudlerMifflin_Solario.Infrastructure.models;

namespace DudlerMifflin_Solario.service;

public class OrdersService
{
    private readonly OrdersInfra _ordersInfra;

    public OrdersService(OrdersInfra ordersInfra)
    {
        _ordersInfra = ordersInfra;
    }

    public IEnumerable<Orders> getAllOrders()
    {
        return _ordersInfra.getAllOrders();
    }

    public Orders createOrder(DateTimeOffset orderDate, DateTime deliveryDate, string status, double totalAmount, int customerId)
    {
        return _ordersInfra.createOrder(orderDate, deliveryDate, status, totalAmount, customerId);
    }

    public Orders updateOrder(int orderId, DateTimeOffset orderDate, DateTime deliveryDate, string status, double totalAmount, int customerId)
    {
        return _ordersInfra.updateOrder(orderId, orderDate, deliveryDate, status, totalAmount, customerId);
    }

    public bool deleteOrder(int orderId)
    {
        return _ordersInfra.deleteOrder(orderId);
    }

    /*public orders getOrderById(int orderId)
    {
        return _ordersDto.getOrderById(orderId);
    }*/
}