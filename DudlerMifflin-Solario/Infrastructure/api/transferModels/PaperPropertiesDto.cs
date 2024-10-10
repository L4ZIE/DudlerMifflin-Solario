using System.Diagnostics.CodeAnalysis;

namespace DudlerMifflin_Solario.Infrastructure.api.transferModels;

public class PaperPropertiesDto
{
    [NotNull]
    public int PaperId { get; set; }
    [NotNull]
    public int PropertyId { get; set; }
}