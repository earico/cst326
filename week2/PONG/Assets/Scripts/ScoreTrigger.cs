using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class ScoreTrigger : MonoBehaviour {
    public ScoreMan scores;
    public int player;
    public GameObject ballPrefab;
    public Transform spawnTransform;
    // Start is called before the first frame update
    void Start() {
        SetScoreText();
    }

    void SetScoreText() {
        scores.scoreText.text = $"{scores.p1Score} - {scores.p2Score}";
    }
    
    // Update is called once per frame
    void Update() {
        
    }

    private void OnTriggerEnter(Collider other) {
        if (player == 1) {
            Debug.Log($"Player 2 scored. Current Score: {scores.p1Score} - {scores.p2Score}");
            scores.p1Score += 1;
            scores.lastScorer = "P1";
            SetScoreText();
            Destroy(other.GameObject());
            Vector3 spawnPosition = spawnTransform.position;
            Instantiate(ballPrefab, spawnPosition, Quaternion.identity);
        }

        if (player == 2) {
            Debug.Log($"Player 1 scored. Current Score: {scores.p1Score} - {scores.p2Score}");
            scores.p2Score += 1;
            scores.lastScorer = "P2";
            SetScoreText();
            Destroy(other.GameObject());
            Vector3 spawnPosition = spawnTransform.position;
            Instantiate(ballPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
