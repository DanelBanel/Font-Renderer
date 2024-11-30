using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public Canvas canvas;
    public Font font;

    void Start()
    {
        // Create a new Text GameObject
        GameObject textGO = new GameObject("Text");
        textGO.transform.SetParent(canvas.transform);

        // Add the Text component
        Text text = textGO.AddComponent<Text>();

        // Set the text properties
        text.text = "Hello, World!";
        text.font = font;
        text.fontSize = 24;
        text.color = Color.black;
        text.alignment = TextAnchor.MiddleCenter;

        // Adjust RectTransform
        RectTransform rectTransform = text.GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(200, 100);
        rectTransform.anchoredPosition = Vector2.zero;
    }
}