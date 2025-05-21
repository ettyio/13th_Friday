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
            PlayerPrefs.Save(); // 저장 확정
            SceneManager.LoadScene("StoryScene"); // 줄거리 씬으로 이동
        }
        else
        {
            Debug.Log("이름을 입력하세요.");
        }
    }
}
