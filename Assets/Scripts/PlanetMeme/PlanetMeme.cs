using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetMeme : MonoBehaviour {
    private const float moveSpeed = 0.5f;

    private PlanetMemeType type = PlanetMemeType.Good;
    private PlanetMemeStatus status = PlanetMemeStatus.Wild;

    private PlanetMemeManager manager = null;

    private int badMemeNum;

    [SerializeField] private SpriteRenderer spriteRenderer = null;

    [SerializeField]
    private Animator spriteAnimator = null;

    /// <summary>
    /// 被生成時 要決定成為怎樣的星球
    /// </summary>
    public void OnGenerated(PlanetMemeType _type, Sprite sp, PlanetMemeManager _manager, Vector3 _targetPos) {
        type = _type;
        status = PlanetMemeStatus.Wild;
        manager = _manager;

        bool isBad = (type == PlanetMemeType.Bad);
        spriteAnimator.enabled = isBad;
        // Set image or something
        if (isBad)
        {
            badMemeNum = Random.Range(0, badMemeType.Count);
            spriteAnimator.SetTrigger(badMemeType[badMemeNum]);
        }
        else
        {
            spriteRenderer.sprite = sp;
        }

        iTween.MoveTo(gameObject, _targetPos, (_targetPos - transform.localPosition).magnitude / moveSpeed);
        //iTween.MoveTo(gameObject, iTween.Hash(
        //        "position", _targetPos,
        //        "speed", moveSpeed,
        //        "easeType", iTween.EaseType.easeInBounce
        //    ));
    }

    /// <summary>
    /// 鉤到了
    /// </summary>
    public void OnHooked() {
        Debug.Log("Planet " + name + " got hooked.");

        iTween.Stop(gameObject);

        // TODO: Effect

        GameManager.Instance.OnHookTypeCallback?.Invoke(type, badMemeNum);
        AudioManagerScript.Instance.CoverPlayAudioClip(badMemeType[badMemeNum]);
    }

    /// <summary>
    /// 被捕獲成為衛星
    /// </summary>
    public void OnCaptured() {
        Debug.Log("Planet " + name + " become a satellite.");

        if (status != PlanetMemeStatus.Satellite)
            status = PlanetMemeStatus.Satellite;
        
        manager.OnPlanetCaptured(gameObject);
    }

    private List<string> badMemeType = new List<string> { "統神", "冰冰姐", "瑞克搖", "蹦蹦姊", "Toyz", "杰哥", "香蕉君" };
}
