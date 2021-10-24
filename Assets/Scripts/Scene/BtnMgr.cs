using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class BtnMgr : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private Animator barAnim;

    public void OnPointerEnter(PointerEventData eventData)
    {
        barAnim.SetBool("Enter", true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        barAnim.SetBool("Enter", false);
    }

    public void ClickToStart()
    {
        AudioManagerScript.Instance.Stop(1);
        SceneManager.LoadScene(1);
    }

    public void ClickToQuit()
    {
        Application.Quit();
    }

    //退出 但同時彈出迷因網頁
    public void ClickToQuitWithMemes()
    {
        //"..." Cat
        Application.OpenURL("https://memeprod.ap-south-1.linodeobjects.com/user-template/7818ccbe151d3f3b456c2cc4f6f67a5d.png");

        //Ricardo Milos
        Application.OpenURL("https://memeprod.ap-south-1.linodeobjects.com/user-gif/28aec28220e46a9ade7f75bd8a915c33.gif");
        
        Application.Quit();
    }
}
