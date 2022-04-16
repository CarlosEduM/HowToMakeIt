using System.Text.Json.Serialization;

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

    public Step(int stepNumber, string description)
    {
        StepNumber = stepNumber;
        Description = description;
    }

    public Step(string description)
    {
        Description = description;
    }

    public Step()
    {
        
    }
}