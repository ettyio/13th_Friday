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
            PlayerPrefs.Save(); // ���� Ȯ��
            SceneManager.LoadScene("StoryScene"); // �ٰŸ� ������ �̵�
        }
        else
        {
            Debug.Log("�̸��� �Է��ϼ���.");
        }
    }
}
