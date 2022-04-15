using HowToMakeItAPI.Models;

namespace HowToMakeItAPI.Services;

public interface ITutorialService
{
    public List<Tutorial> GetAll();

    public List<Tutorial> GetById(int tutorialId);

    public List<Tutorial> GetSearch(string search);

    public void Add(Tutorial newTutorial);

    public void Edit(int tutorialId, Tutorial newTutorial);

    public void Delete(int tutorialId);

}