using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultView : MonoBehaviour {
    [SerializeField] private Button PlayAgainBtn;
    [SerializeField] private Button BackMenuBtn;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private GameObject mainObj;
    [SerializeField] private Text CapturedMemeNum;

    void Start() {
        PlayAgainBtn.onClick.AddListener(OnClickPlayAgainBtn);
        BackMenuBtn.onClick.AddListener(OnClickBackMenuBtn);
    }

    /// <summary>
    /// 進遊戲結算call這個
    /// </summary>
    /// <param name="capturedMemeNum"> 總共抓取的好迷因數量 </param>
    public void OnResult(int capturedMemeNum) {
        BgmManager.Instance.PlayBgmClip("結算bgm");
        CapturedMemeNum.text = capturedMemeNum.ToString();
        iTween.MoveTo(mainCamera.gameObject, iTween.Hash(
                "position", new Vector3(-3.11f, -5.1f, -6.4f),
                "time", 1f,
                "easeType", iTween.EaseType.easeInExpo
            ));
        iTween.ValueTo(gameObject, iTween.Hash(
                "from", 75,
                "to", 29,
                "onUpdate", "OnUpdateCameraFOV",
                "time", 1,
                "easeType", iTween.EaseType.easeInExpo
            ));

        Invoke("DelayActiveMainObj", 1.5f);
    }

    private void DelayActiveMainObj() {
        mainObj.SetActive(true);
    }

    public void OnUpdateCameraFOV(float val) {
        mainCamera.fieldOfView = val;
    }

    public void OnClickPlayAgainBtn() {
        SceneManager.LoadScene("Main");
    }

    public void OnClickBackMenuBtn() {
        SceneManager.LoadScene("Menu");
    }
}
