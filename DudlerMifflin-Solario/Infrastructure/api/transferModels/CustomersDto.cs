using System.Diagnostics.CodeAnalysis;

namespace DudlerMifflin_Solario.Infrastructure.api.transferModels;

public class CustomersDto
{
    [NotNull]
    public string CustomerName { get; set; }
    [NotNull]
    public string Address { get; set; }
    [NotNull]
    public string Phone { get; set; }
    [NotNull]
    public string Email { get; set; }
}