using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialMan : MonoBehaviour
{
   [System.Serializable]
    public class TutorialStep
    {
        [TextArea] public string instructionText;
        public GameObject minigameAnimation;
        public Transform[] targetPositions;
        public GameObject[] objectsToActivate;
        public GameObject[] objectsToDeactivate;
    }

    public TutorialStep[] tutorialSteps;
    public Text instructionTextBox;
    public GameObject[] minigameAnimations;
    public GameObject[] objectsToMove;

    public GameObject ultimoObj;
    public GameObject ultimoObj2;
    public GameObject anima;
    public GameObject anima2;
    public GameObject botaoCena;

    private int currentStep = 0;

    void Start()
    {
        UpdateTutorialStep();
    }

    public void OnClickNextStep()
    {
        if (currentStep < tutorialSteps.Length - 1)
        {
            currentStep++;
            UpdateTutorialStep();
        }
        else
        {
            EndTutorial();
        }
    }

    void UpdateTutorialStep()
    {
        instructionTextBox.text = tutorialSteps[currentStep].instructionText;

        foreach (var animation in minigameAnimations)
        {
            animation.SetActive(false);
        }

        tutorialSteps[currentStep].minigameAnimation.SetActive(true);

        for (int i = 0; i < objectsToMove.Length; i++)
        {
            if (i < tutorialSteps[currentStep].targetPositions.Length)
            {
                objectsToMove[i].transform.position = tutorialSteps[currentStep].targetPositions[i].position;
            }
        }

        foreach (var obj in tutorialSteps[currentStep].objectsToActivate)
        {
            obj.SetActive(true);
        }

        foreach (var obj in tutorialSteps[currentStep].objectsToDeactivate)
        {
            obj.SetActive(false);
        }
    }

    void EndTutorial()
    {
        instructionTextBox.text = "Tutorial Completo!";

        ultimoObj.SetActive(true);
        ultimoObj2.SetActive(true);
        botaoCena.SetActive(true);
        anima.SetActive(false);
        anima2.SetActive(true);

        foreach (var animation in minigameAnimations)
        {
            animation.SetActive(false);
        }
    }
}
