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
            SceneManager.LoadScene("StoryScene"); // ���� �� �̸�
=======
            PlayerPrefs.Save(); // ���� Ȯ��
            SceneManager.LoadScene("StoryScene"); // �ٰŸ� ������ �̵�
>>>>>>> 68550ed651c3e450fa60b2c9982e9fe40eb7d8ad
        }
        else
        {
            Debug.Log("�̸��� �Է��ϼ���.");
        }
    }
}
