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
        throw new NotImplementedException();
    }

    public void Delete(int tutorialId)
    {
        throw new NotImplementedException();
    }

    public void Edit(int tutorialId, Tutorial newTutorial)
    {
        throw new NotImplementedException();
    }

    public List<Tutorial> GetAll() =>
        _context.Tutorials.Include(tutorial => tutorial.StepByStep).ToList();

    public List<Tutorial> GetById(int tutorialId)
    {
        throw new NotImplementedException();
    }

    public List<Tutorial> GetSearch(string search) =>
        _context.Tutorials
            .Where(tutorial => tutorial.TutorialName.Contains(search))
            .Include(tutorial => tutorial.StepByStep)
            .ToList();
}