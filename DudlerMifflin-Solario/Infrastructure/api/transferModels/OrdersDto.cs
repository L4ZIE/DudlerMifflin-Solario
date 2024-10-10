using System.Diagnostics.CodeAnalysis;

namespace DudlerMifflin_Solario.Infrastructure.api.transferModels;

public class OrdersDto
{
    [NotNull]
    public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.UtcNow;
    [NotNull]
    public DateTime DeliveryDate { get; set; } 
    [NotNull]
    public string Status { get; set; } = "Pending";
    [NotNull]
    public double TotalAmount { get; set; }
    [NotNull]
    public int CustomerId { get; set; }
}