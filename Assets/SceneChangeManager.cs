using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeManager : MonoBehaviour
{
    public void LoadStartScene()
    {
        SceneManager.LoadScene("Start Scene");
    }
}
