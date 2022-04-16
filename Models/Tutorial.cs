using System.Text.Json.Serialization;

namespace HowToMakeItAPI.Models;

public class Tutorial
{
    public int Id { get; private set; }
    public string TutorialName { get; set; }

    private readonly List<Step> stepByStep = new List<Step>();
    public List<Step> StepByStep { 
        get { return stepByStep; }
        set {
            SortSteps(value);
        }
    }

    public Tutorial(int id, string tutorialName, List<Step> steps)
    {
        Id = id;
        TutorialName = tutorialName;
        AddStepRange(steps);
    }

    public Tutorial(string tutorialName, List<Step> steps)
    {
        TutorialName = tutorialName;
        AddStepRange(steps);
    }

    public Tutorial(string tutorialName)
    {
        TutorialName = tutorialName;
    }

    public Tutorial()
    {

    }

    public void AddStep(Step newStep)
    {
        newStep.TutorialId = Id;
        StepByStep.Add(newStep);
        SortSteps();
    }

    public void AddStepRange(List<Step> newSteps)
    {
        newSteps.ForEach(ns => ns.TutorialId = Id);
        StepByStep.AddRange(newSteps);
        SortSteps();
    }


    private void SortSteps()
    {
        List<Step> stepsWithoutStepNumber = new List<Step>(StepByStep
            .FindAll(step => step.StepNumber <= 0)
            .OrderByDescending(step => step.StepNumber)
            .ToList());

        List<Step> stepsWithStepNumber = new List<Step>(StepByStep
            .FindAll(step => step.StepNumber > 0)
            .OrderBy(step => step.StepNumber)
            .ToList());

        StepByStep.Clear();
        StepByStep.AddRange(stepsWithStepNumber.Concat(stepsWithoutStepNumber).ToList());

        for (int i = 0; i < StepByStep.Count; i++)
        {
            StepByStep[i].StepNumber = i + 1;
        }
    }

    private List<Step> SortSteps(List<Step> steps)
    {
        List<Step> stepsWithoutStepNumber = steps
            .FindAll(step => step.StepNumber <= 0)
            .OrderByDescending(step => step.StepNumber)
            .ToList();

        List<Step> stepsWithStepNumber = steps
            .FindAll(step => step.StepNumber > 0)
            .OrderBy(step => step.StepNumber)
            .ToList();

        StepByStep.AddRange(stepsWithStepNumber.Concat(stepsWithoutStepNumber).ToList());

        for (int i = 0; i < steps.Count; i++)
        {
            StepByStep[i].StepNumber = i + 1;
        }

        return steps;
    }
}