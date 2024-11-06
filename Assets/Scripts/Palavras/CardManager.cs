using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    public Text scoreText;
    public Text scoreText2;
    public Text highScoreText;
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
        scoreText.text = score.ToString();
        scoreText2.text = "Sua pontuação foi: " + score;
        highScoreText.text = "Melhor pontuação: " + highScore;
    }

    public void UpdateScore(int amount)
    {
        score += amount;
        scoreText.text = score.ToString();
        scoreText2.text = "Sua pontuação foi: " + score;

        if (score > highScore)
        {
            highScore = score;
            highScoreText.text = "Novo Recorde: " + highScore;
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
