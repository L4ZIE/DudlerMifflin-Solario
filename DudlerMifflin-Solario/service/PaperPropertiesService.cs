using DudlerMifflin_Solario.Infrastructure.infra;
using DudlerMifflin_Solario.Infrastructure.models;

namespace DefaultNamespace;

public class PaperPropertiesService
{
    private readonly PaperPropertiesInfra _paperPropertiesInfra;

    public PaperPropertiesService(PaperPropertiesInfra paperPropertiesInfra)
    {
        _paperPropertiesInfra = paperPropertiesInfra;
    }

    public IEnumerable<PaperProperties> getAllPaperProperties()
    {
        return _paperPropertiesInfra.getAllPaperProperties();
    }

    public PaperProperties createPaperProperty(int paperId, int propertyId)
    {
        return _paperPropertiesInfra.createPaperProperty(paperId, propertyId);
    }

    public PaperProperties updatePaperProperty(int paperId, int propertyId)
    {
        return _paperPropertiesInfra.updatePaperProperty(paperId, propertyId);
    }

    public bool deletePaperProperty(int paperId, int propertyId)
    {
        return _paperPropertiesInfra.deletePaperProperty(paperId, propertyId);
    }

   /* public IEnumerable<paperProperties> getPropertiesByPaperId(int paperId)
    {
        return _paperPropertiesDto.getPropertiesByPaperId(paperId);
    }*/
}