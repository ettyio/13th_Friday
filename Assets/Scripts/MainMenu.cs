using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class MainMenu : MonoBehaviour
{
    public string boss_room;

    public void StartGame()
    {
        SceneManager.LoadScene("NameInputScene"); // �� ���� �� �̸�
    }

    public void ShowEditorspage()
    {
        // ������ ���� ǥ�ÿ� ������ ��ȯ�ϰų� �˾�
        SceneManager.LoadScene("Editors Scene");
    }

    public void Showkeypage()
    {
        // ���� Ű �� �Ǵ� UI Ȱ��ȭ
        SceneManager.LoadScene("Explain Key Scene");
    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Start Scene");
    }
}
