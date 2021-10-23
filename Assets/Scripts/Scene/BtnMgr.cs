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
}
