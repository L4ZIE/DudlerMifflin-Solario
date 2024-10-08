using DudlerMifflin_Solario.Infrastructure.dto;
using DudlerMifflin_Solario.Infrastructure.models;

namespace DudlerMifflin_Solario.service;

public class paperService
{
    private readonly paperDTO _paperDto;

    public paperService(paperDTO paperDto)
    {
        _paperDto = paperDto;
    }

    public IEnumerable<paper> getAllPapers()
    {
        return _paperDto.getAllPapers();
    }

    public paper createPaper(string paperName, bool discontinued, int stock, double price)
    {
        return _paperDto.createPaper(paperName, discontinued, stock, price);
    }

    public paper updatePaper(int paperId, string paperName, bool discontinued, int stock, double price)
    {
        return _paperDto.updatePaper(paperId, paperName, discontinued, stock, price);
    }

    public bool deletePaper(int paperId)
    {
        return _paperDto.deletePaper(paperId);
    }

    public paper getPaperById(int paperId)
    {
        return _paperDto.getPaperById(paperId);
    }
}