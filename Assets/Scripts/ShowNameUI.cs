using UnityEngine;
using TMPro;

public class ShowName : MonoBehaviour
{
    public TextMeshProUGUI nameText;  // Inspector�� �����

    void Start()
    {
        if (nameText != null)
            nameText.text = NameManager.playerName;
    }
}