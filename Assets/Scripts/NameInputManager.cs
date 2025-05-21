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
<<<<<<< HEAD
            SceneManager.LoadScene("StoryScene"); // 다음 씬 이름
=======
            PlayerPrefs.Save(); // 저장 확정
            SceneManager.LoadScene("StoryScene"); // 줄거리 씬으로 이동
>>>>>>> 68550ed651c3e450fa60b2c9982e9fe40eb7d8ad
        }
        else
        {
            Debug.Log("이름을 입력하세요.");
        }
    }
}
