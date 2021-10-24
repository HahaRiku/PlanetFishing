using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BtnDetect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
    [SerializeField] private GameObject Bar = null;

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData) {
        Bar.SetActive(true);
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData) {
        Bar.SetActive(false);
    }

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }
}
