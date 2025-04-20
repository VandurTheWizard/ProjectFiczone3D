using TMPro;
using UnityEngine;

public class TextInput : MonoBehaviour
{
    private TMP_InputField inputField;

    void Start()
    {
        inputField = GetComponent<TMP_InputField>();
        inputField.characterLimit = 3;
        inputField.onValueChanged.AddListener(ForceUpperCase);
    }

    void ForceUpperCase(string text)
    {
        string filtered = "";
        foreach (char c in text)
        {
            if (char.IsLetter(c))
            {
                filtered += char.ToUpper(c);
            }
        }

        if (inputField.text != filtered)
        {
            inputField.text = filtered;
            inputField.caretPosition = filtered.Length;
        }
    }
}
