using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeManager : MonoBehaviour
{
    public void LoadStartScene1()
    {
        SceneManager.LoadScene("STAGE1");
    }
}
