using HowToMakeItAPI.Data;
using HowToMakeItAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HowToMakeItAPI.Services;

public class TutorialPostgresService : ITutorialService
{
    private readonly PostgresContext _context;

    public TutorialPostgresService(PostgresContext context)
    {
        _context = context;
    }

    public void Add(Tutorial newTutorial)
    {
        _context.Tutorials.Add(newTutorial);
        _context.SaveChanges();
    }

    public void Delete(Tutorial tutorial)
    {
        _context.Tutorials.Remove(tutorial);
        _context.SaveChanges();
    }

    public void Edit(Tutorial tutorial)
    {
        _context.Tutorials.Update(tutorial).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public List<Tutorial> GetAll() =>
        _context.Tutorials.Include(tutorial => tutorial.StepByStep).ToList();

    public Tutorial GetById(int tutorialId) => 
        _context.Tutorials
            .Include(tutorial => tutorial.StepByStep)
            .FirstOrDefault(t => t.Id == tutorialId);

    public List<Tutorial> GetSearch(string search) =>
        _context.Tutorials
            .Include(tutorial => tutorial.StepByStep)
            .Where(tutorial => tutorial.TutorialName.Contains(search))
            .ToList();
}