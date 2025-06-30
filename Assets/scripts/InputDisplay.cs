using UnityEngine;
using TMPro;

public class InputUpdate : MonoBehaviour
{
    public TMP_InputField inputField;   // Reference to input field
    public TMP_Text displayText;        // Reference to display text

    void Start()
    {
        // When text changes in input field, call UpdateDisplayText function
        inputField.onValueChanged.AddListener(UpdateDisplayText);
    }

    void UpdateDisplayText(string text)
    {
        displayText.text = text; // Real-time show the typed text
    }
}

