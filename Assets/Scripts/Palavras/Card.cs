using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public string word;
    public bool isAnimal;
    public CardGenerator generator;

    public GameObject feedbackTextPrefab;

    private CardManager cardManager;
    private Canvas canvas;

    void Start()
    {
        cardManager = FindObjectOfType<CardManager>();
        canvas = FindObjectOfType<Canvas>();

        if (canvas == null)
        {
            Debug.LogError("Nenhum Canvas foi encontrado na cena. Certifique-se de que há um Canvas ativo.");
        }

        GetComponentInChildren<Text>().text = word;
    }

    public void OnCardClick()
    {
        if (isAnimal)
        {
            cardManager.UpdateScore(10);
            cardManager.CardClicked(isAnimal);

            if (feedbackTextPrefab != null && canvas != null)
            {
                Vector2 clickPosition = Input.mousePosition;

                if (canvas.renderMode == RenderMode.ScreenSpaceOverlay)
                {
                    SpawnFeedbackAtScreenSpaceOverlay(clickPosition);
                }
                else if (canvas.renderMode == RenderMode.ScreenSpaceCamera || canvas.renderMode == RenderMode.WorldSpace)
                {
                    SpawnFeedbackAtScreenSpaceCameraOrWorldSpace(clickPosition);
                }
            }

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

    private void SpawnFeedbackAtScreenSpaceOverlay(Vector2 clickPosition)
    {
        GameObject feedback = Instantiate(feedbackTextPrefab, canvas.transform);
        feedback.GetComponent<RectTransform>().position = clickPosition;
    }

    private void SpawnFeedbackAtScreenSpaceCameraOrWorldSpace(Vector2 clickPosition)
    {
        RectTransform canvasRect = canvas.GetComponent<RectTransform>();
        Vector2 localPoint;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvasRect,
            clickPosition,
            canvas.worldCamera,
            out localPoint
        );

        GameObject feedback = Instantiate(feedbackTextPrefab, canvas.transform);
        feedback.GetComponent<RectTransform>().anchoredPosition = localPoint;
    }
}