using UnityEngine;
using TMPro;

public class ShowName : MonoBehaviour
{
    public TextMeshProUGUI nameText;  // Inspectorø° ≥Î√‚µ 

    void Start()
    {
        if (nameText != null)
            nameText.text = NameManager.playerName;
    }
}