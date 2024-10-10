namespace DudlerMifflin_Solario.Infrastructure.models;

public class OrderEntries
{
    public int Id { get; set; }
    public int quantity { get; set; }
    public int productId { get; set; }
    public int orderId { get; set; }
}