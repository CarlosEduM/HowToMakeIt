namespace HowToMakeItAPI.Models;

public class Tutorial
{
    public int Id { get; private set; }
    public string TutorialName { get; set; }
    public List<Step> StepByStep { get; } = new List<Step>();

    public Tutorial(int id, string tutorialName, List<Step> steps)
    {
        Id = id;
        TutorialName = tutorialName;
        AddStepRange(steps);
    }
    public Tutorial(int id, string tutorialName)
    {
        Id = id;
        TutorialName = tutorialName;
    }

    public Tutorial(string tutorialName)
    {
        TutorialName = tutorialName;
        StepByStep = new List<Step>();
    }

    public void AddStep(Step newStep)
    {
        StepByStep.Add(newStep);
        SortSteps();
    }

    public void AddStepRange(List<Step> newSteps)
    {
        StepByStep.AddRange(newSteps);
        SortSteps();
    }


    private void SortSteps()
    {
        List<Step> stepsWithoutStepNumber = StepByStep
            .FindAll(step => step.StepNumber <= 0)
            .OrderByDescending(step => step.StepNumber)
            .ToList();
        List<Step> stepsWithStepNumber = StepByStep
            .FindAll(step => step.StepNumber > 0)
            .OrderBy(step => step.StepNumber)
            .ToList();

        StepByStep.Clear();
        StepByStep.AddRange(stepsWithStepNumber.Concat(stepsWithoutStepNumber).ToList());

        for (int i = 0; i < StepByStep.Count; i++)
        {
            StepByStep[0].StepNumber = i + 1;
        }
    }
}