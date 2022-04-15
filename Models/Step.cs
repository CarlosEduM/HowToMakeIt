namespace HowToMakeItAPI.Models;

public class Step
{
    public int Id { get; private set; }
    public int StepNumber { get; set; }
    public string Description { get; set; }
    public int TutorialId { get; set; }

    public Step(int id, int stepNumber, string description, int tutorialId)
    {
        Id = id;
        StepNumber = stepNumber;
        Description = description;
        TutorialId = tutorialId;
    }

    public Step(int stepNumber, string description, int tutorialId)
    {
        StepNumber = stepNumber;
        Description = description;
        TutorialId = tutorialId;
    }

    public Step(string description, int tutorialId)
    {
        Description = description;
        TutorialId = tutorialId;
    }
}