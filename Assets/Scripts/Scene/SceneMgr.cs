using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMgr : MonoBehaviour
{
    public void ClickToStart()
    {
        SceneManager.LoadScene(1);
    }

    public void ClickToQuit()
    {
        Application.Quit();
    }
}
