using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeManager1 : MonoBehaviour
{
    public void LoadStartScene1()
    {
        SceneManager.LoadScene("STAGE1");
    }

    public void LoadStartScene2()
    {
        SceneManager.LoadScene("STAGE2");
    }
}