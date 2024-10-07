using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    public Text scoreText;
    private int score;
    private int totalAnimalCards;

    public CardGenerator cardGenerator;
    public int correctStreak = 0;
    private bool hasIncreasedCards = false;

    void Start()
    {
        cardGenerator = FindObjectOfType<CardGenerator>();
    }

    public void UpdateScore(int amount)
    {
        score += amount;
        scoreText.text = "Score: " + score;
    }

    public void ResetAnimalCounter(int totalAnimals)
    {
        totalAnimalCards = totalAnimals;
    }

    public void CardClicked(bool isAnimal)
    {
        if (isAnimal)
        {
            correctStreak++;
            Debug.Log("clickou");
            
            if (correctStreak == 4 && !hasIncreasedCards)
            {
                cardGenerator.IncreaseCards();
                hasIncreasedCards = true;
            }
        }
        else
        {
            correctStreak = 0;
        }
    }
}
