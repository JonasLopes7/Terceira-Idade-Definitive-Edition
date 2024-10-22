using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    public Text scoreText;
    public Text scoreText2;
    private int score;
    private int totalAnimalCards;
    private int highScore;

    public CardGenerator cardGenerator;
    public int correctStreak = 0;
    private bool hasIncreasedCards = false;

    void Start()
    {
        cardGenerator = FindObjectOfType<CardGenerator>();

        highScore = PlayerPrefs.GetInt("HighScoreCard", 0);

        score = 0;
        scoreText.text = "Score: " + score;
        scoreText2.text = "Score: " + score;
    }

    public void UpdateScore(int amount)
    {
        score += amount;
        scoreText.text = "Score: " + score;
        scoreText2.text = "Score: " + score;

        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScoreCard", highScore);
            PlayerPrefs.Save();
        }
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
