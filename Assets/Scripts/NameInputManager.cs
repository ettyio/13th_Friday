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
            SceneManager.LoadScene("StoryScene"); // 다음 씬 이름
        }
        else
        {
            Debug.Log("이름을 입력하세요.");
        }
    }

    public void OnSubmitName()
    {
        NameManager.playerName = nameInputField.text;
        SceneManager.LoadScene("STAGE1");
    }
}
