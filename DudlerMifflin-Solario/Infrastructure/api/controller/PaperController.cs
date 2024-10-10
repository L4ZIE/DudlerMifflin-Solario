using DudlerMifflin_Solario.Infrastructure.api.transferModels;
using DudlerMifflin_Solario.Infrastructure.infra;
using DudlerMifflin_Solario.Infrastructure.models;
using DudlerMifflin_Solario.service;
using Microsoft.AspNetCore.Mvc;

namespace DudlerMifflin_Solario.Infrastructure.api;


[ApiController]
public class PaperController : ControllerBase
{
    private readonly PaperService _paperService;

    public PaperController(PaperService paperService)
    {
        _paperService = paperService;
    }

    [HttpGet]
    [Route("/api/paper")]
    public IEnumerable<Paper> getPapers()
    {
        return _paperService.getAllPapers();
    }

    [HttpPost]
    [Route("/api/paper/create")]
    public Paper Create([FromBody] PaperDto dto)
    {
        return _paperService.createPaper(dto.PaperName, dto.Discontinued, dto.Stock, dto.Price);
    }

    [HttpPut]
    [Route("/api/paper/update/{paperId}")]
    public Paper Put([FromRoute] int paperId, [FromBody] PaperDto dto)
    {
        return _paperService.updatePaper(paperId, dto.PaperName, dto.Discontinued, dto.Stock, dto.Price);
    }

    [HttpDelete]
    [Route("/api/paper/delete/{paperId}")]
    public bool Delete([FromRoute] int paperId)
    {
        return _paperService.deletePaper(paperId);
    }
}