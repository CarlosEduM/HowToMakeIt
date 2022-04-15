using HowToMakeItAPI.Data;
using HowToMakeItAPI.Models;

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

    public List<Tutorial> GetAll()
    {
        throw new NotImplementedException();
    }

    public List<Tutorial> GetById(int tutorialId)
    {
        throw new NotImplementedException();
    }

    public List<Tutorial> GetSearch(string search)
    {
        throw new NotImplementedException();
    }
}