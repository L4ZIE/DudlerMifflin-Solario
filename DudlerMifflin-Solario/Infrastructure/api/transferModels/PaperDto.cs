using System.Diagnostics.CodeAnalysis;

namespace DudlerMifflin_Solario.Infrastructure.api.transferModels;

public class PaperDto
{
    [NotNull]
    public string PaperName { get; set; }
    [NotNull]
    public bool Discontinued { get; set; }
    [NotNull]
    public int Stock { get; set; }
    [NotNull]
    public double Price { get; set; }
}