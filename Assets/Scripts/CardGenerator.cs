using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class CardGenerator : MonoBehaviour
{
    public GameObject cardPrefab; 
    public Transform cardParent; 
    public int rows = 3; 
    public int columns = 4; 
    public List<string> animalWords; 
    public List<string> normalWords; 
    public int totalCards = 12; 
    public int animalCardCount = 4; 

    private List<string> selectedWords; 
    private List<string> selectedAnimalWords; 

    void Start()
    {
        GenerateCards();
    }

    void GenerateCards()
    {
        selectedWords = new List<string>();
        selectedAnimalWords = new List<string>(); 

        for (int i = 0; i < animalCardCount; i++)
        {
            int randomIndex = Random.Range(0, animalWords.Count);
            selectedWords.Add(animalWords[randomIndex]);
            selectedAnimalWords.Add(animalWords[randomIndex]); 
            animalWords.RemoveAt(randomIndex); 
        }

        for (int i = 0; i < totalCards - animalCardCount; i++)
        {
            int randomIndex = Random.Range(0, normalWords.Count);
            selectedWords.Add(normalWords[randomIndex]);
            normalWords.RemoveAt(randomIndex);
        }

        Shuffle(selectedWords);
        CreateGrid();
    }

    void Shuffle(List<string> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int randomIndex = Random.Range(0, list.Count);
            string temp = list[i];
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }

    void CreateGrid()
    {
        RectTransform parentRect = cardParent.GetComponent<RectTransform>();
        float totalWidth = parentRect.rect.width;
        float totalHeight = parentRect.rect.height;
        float cardWidth = totalWidth / columns;
        float cardHeight = totalHeight / rows;
        float spacingX = cardWidth * 0.1f; 
        float spacingY = cardHeight * 0.1f; 

        cardWidth -= spacingX;
        cardHeight -= spacingY;

        for (int i = 0; i < totalCards; i++)
        {
            GameObject newCard = Instantiate(cardPrefab, cardParent);
            int row = i / columns;
            int column = i % columns;
            float xPos = (column * (cardWidth + spacingX)) - (totalWidth / 2) + (cardWidth / 2);
            float yPos = -(row * (cardHeight + spacingY)) + (totalHeight / 2) - (cardHeight / 2);
            newCard.GetComponent<RectTransform>().anchoredPosition = new Vector2(xPos, yPos);
            Card cardScript = newCard.GetComponent<Card>();
            cardScript.word = selectedWords[i];
            cardScript.isAnimal = selectedAnimalWords.Contains(cardScript.word);
            cardScript.scoreValue = cardScript.isAnimal ? 10 : -5; 
        }
    }
}