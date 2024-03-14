using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    public AudioClip playerShoot,
        enemyShoot,
        playerExpl,
        enemyExpl,
        playerCharge;

    private AudioSource pSFX;
    private AudioSource eSFX;
    void Start() {
        pSFX = gameObject.AddComponent<AudioSource>();
        pSFX.volume = 0.2f;

        eSFX = gameObject.AddComponent<AudioSource>();
        eSFX.volume = 0.2f;
    }

    public void PlaySFX(String audioClip) {
        
        switch (audioClip) {
            case "pExplosion":
                eSFX.clip = playerExpl;
                eSFX.Play();
                break;
            case "pCharge":
                pSFX.clip = playerCharge;
                pSFX.Play();
                break;
        }
    }

    public void StopSFX() {
        eSFX.Stop();
        pSFX.Stop();
    }
    
    void Update() {
        
    }
}
