using HowToMakeItAPI.Models;
using HowToMakeItAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        return (tutorial != null) ? Ok(tutorial) : NotFound();
    }

    [HttpPost]
    public IActionResult Create(Tutorial tutorial)
    {
        _service.Add(tutorial);

        return CreatedAtAction(nameof(Create), new { id = tutorial.Id }, tutorial);
    }

    [HttpPut("{id}")]
    public IActionResult Edit([FromRoute] int id, [FromBody] Tutorial tutorial)
    {
        if (id != tutorial.Id)
        {
            return BadRequest();
        }

        try
        {
            _service.Edit(tutorial);

            return NoContent();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (_service.GetById(id) == null)
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        Tutorial tutorial = _service.GetById(id);

        if (tutorial == null)
        {
            return NotFound();
        }

        _service.Delete(tutorial);

        return NoContent();
    }
}