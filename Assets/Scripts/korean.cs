using UnityEngine;
using TMPro;

public class TMPIMEFix : MonoBehaviour
{
    public TMP_InputField inputField;

    void Update()
    {
        if (inputField.isFocused)
        {
            Vector2 pos = inputField.textViewport.position;
            Input.imeCompositionMode = IMECompositionMode.On;
            Input.compositionCursorPos = pos;
        }
    }
}
