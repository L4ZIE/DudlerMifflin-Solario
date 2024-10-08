using DudlerMifflin_Solario.Infrastructure.dto;
using DudlerMifflin_Solario.Infrastructure.models;

namespace DudlerMifflin_Solario.service;

public class orderEntriesService
{
    private readonly orderEntriesDTO _orderEntriesDto;

    public OrderEntriesService(orderEntriesDTO orderEntriesDto)
    {
        _orderEntriesDto = orderEntriesDto;
    }

    public IEnumerable<orderEntries> getAllOrderEntries()
    {
        return _orderEntriesDto.getAllOrderEntries();
    }

    public orderEntries createOrderEntry(int quantity, int productId, int orderId)
    {
        return _orderEntriesDto.createOrderEntry(quantity, productId, orderId);
    }

    public orderEntries updateOrderEntry(int id, int quantity, int productId, int orderId)
    {
        return _orderEntriesDto.updateOrderEntry(id, quantity, productId, orderId);
    }

    public bool deleteOrderEntry(int id)
    {
        return _orderEntriesDto.deleteOrderEntry(id);
    }
    
    public IEnumerable<orderEntries> getOrderEntriesByOrderId(int orderId)
    {
        return _orderEntriesDto.getOrderEntriesByOrderId(orderId);
    }
}