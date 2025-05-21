using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class NameInputManager : MonoBehaviour
{
    public TMP_InputField nameInputField;

    public void OnStartButtonClicked()
    {
        string playerName = nameInputField.text.Trim();

        if (!string.IsNullOrEmpty(playerName))
        {
            PlayerPrefs.SetString("PlayerName", playerName);
            SceneManager.LoadScene("StoryScene"); // ���� �� �̸�
        }
        else
        {
            Debug.Log("�̸��� �Է��ϼ���.");
        }
    }

    public void OnSubmitName()
    {
        NameManager.playerName = nameInputField.text;
        SceneManager.LoadScene("STAGE1");
    }
}
