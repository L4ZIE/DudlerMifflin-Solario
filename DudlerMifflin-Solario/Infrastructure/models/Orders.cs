namespace DudlerMifflin_Solario.Infrastructure.models;

public class Orders
{
    public int OrderId { get; set; }
    public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.UtcNow;
    public DateTime DeliveryDate { get; set; } 
    public string Status { get; set; } = "Pending";
    public double TotalAmount { get; set; }
    public int CustomerId { get; set; }
}