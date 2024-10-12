using DudlerMifflin_Solario.Infrastructure.models;
using DudlerMifflin_Solario.service;
using Microsoft.AspNetCore.Mvc;

namespace DudlerMifflin_Solario.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PaperController : ControllerBase
{
    private readonly paperService _paperService;

    public PaperController(paperService paperService)
    {
        _paperService = paperService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<paper>> GetAllPapers()
    {
        var papers = _paperService.getAllPapers();
        return Ok(papers);
    }

    [HttpPost]
    public ActionResult<paper> CreatePaper([FromBody] paper newPaper)
    {
        if (newPaper == null)
        {
            return BadRequest("Invalid data.");
        }

        var createdPaper =
            _paperService.createPaper(newPaper.PaperName, newPaper.Discontinued, newPaper.Stock, newPaper.Price);
        return Ok(createdPaper);
    }

    [HttpPut("{id}")]
    public ActionResult<paper> UpdatePaper(int id, [FromBody] paper updatedPaper)
    {
        if (updatedPaper == null || updatedPaper.PaperId != id)
        {
            return BadRequest("Invalid product data.");
        }

        var existingPaper = _paperService.getPaperById(id);
        if (existingPaper == null)
        {
            return NotFound($"Product with ID {id} not found.");
        }
        
        var updated = _paperService.updatePaper(id, updatedPaper.PaperName, updatedPaper.Discontinued, updatedPaper.Stock, updatedPaper.Price);
        return Ok(updated);
    }

}