using DudlerMifflin_Solario.Infrastructure.dto;
using DudlerMifflin_Solario.Infrastructure.models;

namespace DudlerMifflin_Solario.service;

public class propertiesService
{
    private readonly propertiesDTO _propertiesDto;

    public propertiesService(propertiesDTO propertiesDto)
    {
        _propertiesDto = propertiesDto;
    }

    public IEnumerable<properties> getAllProperties()
    {
        return _propertiesDto.getAllProperties();
    }

    public properties createProperty(string propertyName)
    {
        return _propertiesDto.createProperty(propertyName);
    }

    public properties updateProperty(int id, string propertyName)
    {
        return _propertiesDto.updateProperty(id, propertyName);
    }

    public bool deleteProperty(int id)
    {
        return _propertiesDto.deleteProperty(id);
    }

    public properties getPropertyById(int id)
    {
        return _propertiesDto.getPropertyById(id);
    }
}