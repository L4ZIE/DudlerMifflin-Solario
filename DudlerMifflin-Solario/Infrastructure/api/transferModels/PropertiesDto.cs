using System.Diagnostics.CodeAnalysis;

namespace DudlerMifflin_Solario.Infrastructure.api.transferModels;

public class PropertiesDto
{
    [NotNull]
    public string PropertyName { get; set; }
}