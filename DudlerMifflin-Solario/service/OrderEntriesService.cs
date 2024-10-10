using DudlerMifflin_Solario.Infrastructure.infra;
using DudlerMifflin_Solario.Infrastructure.models;

namespace DudlerMifflin_Solario.service;

public class OrderEntriesService
{
    private readonly OrderEntriesInfra _orderEntriesInfra;

    public OrderEntriesService(OrderEntriesInfra orderEntriesInfra)
    {
        _orderEntriesInfra = orderEntriesInfra;
    }

    public IEnumerable<OrderEntries> getAllOrderEntries()
    {
        return _orderEntriesInfra.getAllOrderEntries();
    }

    public OrderEntries createOrderEntry(int quantity, int productId, int orderId)
    {
        return _orderEntriesInfra.createOrderEntry(quantity, productId, orderId);
    }

    public OrderEntries updateOrderEntry(int id, int quantity, int productId, int orderId)
    {
        return _orderEntriesInfra.updateOrderEntry(id, quantity, productId, orderId);
    }

    public bool deleteOrderEntry(int id)
    {
        return _orderEntriesInfra.deleteOrderEntry(id);
    }
    
   /* public IEnumerable<orderEntries> getOrderEntriesByOrderId(int orderId)
    {
        return _orderEntriesDto.getOrderEntriesByOrderId(orderId);
    }*/
}