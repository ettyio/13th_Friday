using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class StoryTyper : MonoBehaviour
{
    public TextMeshProUGUI storyText;
    public Button skipButton;

    [TextArea(3, 10)]
    public string[] storyLines;

    public float typingSpeed = 0.05f;
    private bool isSkipping = false;
    private Coroutine typingCoroutine;

    private void Start()
    {
        skipButton.onClick.AddListener(SkipStory);

        // 이름 불러오기 & 삽입
        string playerName = PlayerPrefs.GetString("PlayerName", "이름없는 용사");
        for (int i = 0; i < storyLines.Length; i++)
        {
            storyLines[i] = storyLines[i].Replace("{{name}}", playerName);
        }

        typingCoroutine = StartCoroutine(TypeStory());
    }

    IEnumerator TypeStory()
    {
        for (int i = 0; i < storyLines.Length; i++)
        {
            yield return StartCoroutine(TypeLine(storyLines[i]));
            yield return new WaitForSeconds(1f); // 다음 줄 전 대기
            if (isSkipping) yield break;
        }

        LoadGameScene();
    }

    IEnumerator TypeLine(string line)
    {
        storyText.text = "";
        foreach (char c in line)
        {
            if (isSkipping) yield break;
            storyText.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void SkipStory()
    {
        isSkipping = true;
        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine);
        LoadGameScene();
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene("STAGE1"); // 다음 씬 이름
    }
}
