using HowToMakeItAPI.Models;
using HowToMakeItAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace HowToMakeItAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class TutorialController : ControllerBase
{
    private readonly ITutorialService _service;

    public TutorialController(ITutorialService service)
    {
        _service = service;
    }

    [HttpGet]
    public ActionResult<List<Tutorial>> GetAll([FromQuery] string? search)
        => (search != null || search != "") ? _service.GetSearch(search) : _service.GetAll();

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var tutorial = _service.GetById(id);

        return (tutorial != null)? Ok(tutorial): NotFound();
    }

    [HttpPost]
    public IActionResult Create(Tutorial tutorial)
    {
        _service.Add(tutorial);

        return CreatedAtAction(nameof(Create), new { id = tutorial.Id }, tutorial);
    }
}