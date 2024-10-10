using DudlerMifflin_Solario.Infrastructure.infra;
using DudlerMifflin_Solario.Infrastructure.models;

namespace DudlerMifflin_Solario.service;

public class PaperService
{
    private readonly PaperInfra _paperInfra;

    public PaperService(PaperInfra paperInfra)
    {
        _paperInfra = paperInfra;
    }

    public IEnumerable<Paper> getAllPapers()
    {
        return _paperInfra.getAllPapers();
    }

    public Paper createPaper(string paperName, bool discontinued, int stock, double price)
    {
        return _paperInfra.createPaper(paperName, discontinued, stock, price);
    }

    public Paper updatePaper(int paperId, string paperName, bool discontinued, int stock, double price)
    {
        return _paperInfra.updatePaper(paperId, paperName, discontinued, stock, price);
    }

    public bool deletePaper(int paperId)
    {
        return _paperInfra.deletePaper(paperId);
    }

    /*public paper getPaperById(int paperId)
    {
        return _paperDto.getPaperById(paperId);
    }*/
}