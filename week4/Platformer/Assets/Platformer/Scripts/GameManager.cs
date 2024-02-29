using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI coinCount;
    
    public int coins = 0;
    public int score = 0;

    public AudioSource brickBreak;
    public AudioSource coinGet;
    // Start is called before the first frame update
    void Start() {
        scoreText.text = $"SCORE\n{score:000000}";
        coinCount.text = $"(/) x {coins:00}";
    }

    public void SetTextUpdate() {
        scoreText.text = $"SCORE\n{score:000000}";
        coinCount.text = $"(/) x {coins:00}";
    }

    // Update is called once per frame
    void Update() {
        int intTime = 100 - (int)Time.realtimeSinceStartup;
        timerText.text = $"TIME\n{intTime}";

        if (intTime <= 0) {
            Debug.Log("Player ran out of time! Game Over!");
        }
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
            if (hit.collider.name == "Brick(Clone)" && Input.GetMouseButtonDown(0)) {
                brickBreak.Play();
                score += 100;
                SetTextUpdate();
                Destroy(hit.collider.gameObject);
                Debug.Log($"HIT BRICK");
            }
        
            else if (hit.collider.name == "Question(Clone)" && Input.GetMouseButtonDown(0)) {
                coinGet.Play();
                coins++;
                score += 100;
                SetTextUpdate();
                Debug.Log($"HIT QUESTION");
            }
    }
}
