using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public string word;
    public bool isAnimal;
    public CardGenerator generator;

    private CardManager cardManager;

    void Start()
    {
        cardManager = FindObjectOfType<CardManager>();
        GetComponentInChildren<Text>().text = word;
    }

    public void OnCardClick()
    {
        if (isAnimal)
        {
            cardManager.UpdateScore(10);
            cardManager.CardClicked(isAnimal);
            Destroy(gameObject);
            generator.currentAnimalCards.Remove(word); 

            if (generator.currentAnimalCards.Count == 0)
            {
                generator.OnAllAnimalsClicked();
            }
        }
        else
        {
            cardManager.CardClicked(isAnimal);
            generator.OnWrongWordClick();
        }
    }
}