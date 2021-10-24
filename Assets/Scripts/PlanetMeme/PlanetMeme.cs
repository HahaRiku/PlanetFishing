using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetMeme : MonoBehaviour {
    private const float moveSpeed = 0.5f;

    private PlanetMemeType type = PlanetMemeType.Good;
    private PlanetMemeStatus status = PlanetMemeStatus.Wild;

    private PlanetMemeManager manager = null;

    [SerializeField] private SpriteRenderer spriteRenderer = null;
    
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    /// <summary>
    /// 被生成時 要決定成為怎樣的星球
    /// </summary>
    public void OnGenerated(PlanetMemeType _type, Sprite sp, PlanetMemeManager _manager, Vector3 _targetPos) {
        type = _type;
        status = PlanetMemeStatus.Wild;
        manager = _manager;

        // Set image or something
        spriteRenderer.sprite = sp;

        //iTween.MoveTo(gameObject, _targetPos, (_targetPos - transform.localPosition).magnitude / moveSpeed);
        iTween.MoveTo(gameObject, iTween.Hash(
                "position", _targetPos,
                "speed", moveSpeed,
                "easeType", iTween.EaseType.easeInBounce
            ));
    }

    /// <summary>
    /// 鉤到了
    /// </summary>
    public void OnHooked() {
        Debug.Log("Planet " + name + " got hooked.");

        iTween.Stop(gameObject);

        // TODO: Effect


    }

    /// <summary>
    /// 被捕獲成為衛星
    /// </summary>
    public void OnCaptured() {
        Debug.Log("Planet " + name + " become a satellite.");

        status = PlanetMemeStatus.Satellite;
        
        manager.OnPlanetCaptured(gameObject);
    }
}
