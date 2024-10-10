using System.Diagnostics.CodeAnalysis;

namespace DudlerMifflin_Solario.Infrastructure.api.transferModels;

public class OrderEntriesDto
{
    [NotNull]
    public int quantity { get; set; }
    [NotNull]
    public int productId { get; set; }
    [NotNull]
    public int orderId { get; set; }
}