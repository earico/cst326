using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class SlotTrigger : MonoBehaviour {
    public int slotNumber;
    public int points;
    public Score scoreS;
    
    void SetScoreText() {
        scoreS.scoreText.text = $"SCORE\n{scoreS.score}";
    }
    
    // Start is called before the first frame update
    void Start() {
        SetScoreText();
    }

    // Update is called once per frame
    void Update() {
        
    }

    private void OnTriggerEnter(Collider other) {
        //scoreS = GetComponent<Score>();
        Debug.Log($"Entered slot {slotNumber} and got {points}");
        scoreS.score += points;
        Debug.Log($"score: points: {points}");
        SetScoreText();
        Destroy(other.GameObject());
        
    }
}
