using DudlerMifflin_Solario.Infrastructure.dto;
using DudlerMifflin_Solario.Infrastructure.models;

namespace DefaultNamespace;

public class paperPropertiesService
{
    private readonly paperPropertiesDTO _paperPropertiesDto;

    public paperPropertiesService(paperPropertiesDTO paperPropertiesDto)
    {
        _paperPropertiesDto = paperPropertiesDto;
    }

    public IEnumerable<paperProperties> getAllPaperProperties()
    {
        return _paperPropertiesDto.getAllPaperProperties();
    }

    public paperProperties createPaperProperty(int paperId, int propertyId)
    {
        return _paperPropertiesDto.createPaperProperty(paperId, propertyId);
    }

    public paperProperties updatePaperProperty(int paperId, int propertyId)
    {
        return _paperPropertiesDto.updatePaperProperty(paperId, propertyId);
    }

    public bool deletePaperProperty(int paperId, int propertyId)
    {
        return _paperPropertiesDto.deletePaperProperty(paperId, propertyId);
    }

    public IEnumerable<paperProperties> getPropertiesByPaperId(int paperId)
    {
        return _paperPropertiesDto.getPropertiesByPaperId(paperId);
    }
}