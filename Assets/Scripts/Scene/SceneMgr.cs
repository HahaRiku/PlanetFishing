using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMgr : MonoBehaviour
{
    public void ClickToStart()
    {
        SceneManager.LoadScene(1);
        Debug.Log("點擊開始遊戲");
    }

    public void ClickOptions()
    {
        Debug.Log("點擊設定");
    }

    public void ClickToQuit()
    {
        Debug.Log("點擊離開遊戲");
        Application.Quit();
    }
}
