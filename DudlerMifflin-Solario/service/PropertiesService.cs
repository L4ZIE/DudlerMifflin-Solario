using DudlerMifflin_Solario.Infrastructure.infra;
using DudlerMifflin_Solario.Infrastructure.models;

namespace DudlerMifflin_Solario.service;

public class PropertiesService
{
    private readonly PropertiesInfra _propertiesInfra;

    public PropertiesService(PropertiesInfra propertiesInfra)
    {
        _propertiesInfra = propertiesInfra;
    }

    public IEnumerable<Properties> getAllProperties()
    {
        return _propertiesInfra.getAllProperties();
    }

    public Properties createProperty(string propertyName)
    {
        return _propertiesInfra.createProperty(propertyName);
    }

    public Properties updateProperty(int id, string propertyName)
    {
        return _propertiesInfra.updateProperty(id, propertyName);
    }

    public bool deleteProperty(int id)
    {
        return _propertiesInfra.deleteProperty(id);
    }

    /*public properties getPropertyById(int id)
    {
        return _propertiesDto.getPropertyById(id);
    }*/
}