using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("boss_room"); // 본 게임 씬 이름
    }

    public void ShowEditorspage()
    {
        // 제작자 정보 표시용 씬으로 전환하거나 팝업
        SceneManager.LoadScene("Editors Scene");
    }

    public void Showkeypage()
    {
        // 설명 키 씬 또는 UI 활성화
        SceneManager.LoadScene("Explain Key Scene");
    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Start Scene");
    }
}
