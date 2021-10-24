using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmManager : MonoBehaviour {
    public static BgmManager Instance = null;
    [SerializeField] private AudiosPack audiosPack;

    [SerializeField] private AudioSource BgmAudioSource = null;

    // Start is called before the first frame update
    void Start() {
        if(Instance == null) {
            Instance = this;
        }
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void PlayBgmClip(string name) {
        for(int i = 0; i < audiosPack.clipsPack.Count; i++) {
            if(name == audiosPack.clipsPack[i].GetName) {
                BgmAudioSource.clip = audiosPack.clipsPack[i].GetClips[0];
                BgmAudioSource.Play();
            }
        }

    }
}
