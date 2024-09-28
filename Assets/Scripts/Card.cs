using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public string word; 
    public bool isAnimal; 
    public int scoreValue; 
    
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
            cardManager.UpdateScore(scoreValue);
        }
        else
        {
            cardManager.UpdateScore(-Mathf.Abs(scoreValue));
        }

        Destroy(gameObject);
    }
}