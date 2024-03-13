using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using TMPro;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class GameManager : MonoBehaviour {
    public int score, hiScore = 0;
    public int enemyCount = 36;
    public TextMeshProUGUI scoreText, hiScoreText, resultsText;
    public GameObject barrage, barricade;
    public GameObject enemyStart;
    public GameObject barricadeStart;

    private String dir = "right";
    
    // Start is called before the first frame update
    void Start() {
        SetScoreText();
        Setup();
    }

    void Setup() {
        Vector3 eStart = enemyStart.transform.position;
        Vector3 bStart = barricadeStart.transform.position;

        Instantiate(barrage, eStart, Quaternion.identity);

        for (int i = 0; i < 4; i++) {
            Instantiate(barricade, bStart, Quaternion.identity);
            bStart += new Vector3(8, 0, 0);
        }
    }
    
    public void SetScoreText() {
        if (score > hiScore) {
            hiScore = score;
        }

        if (enemyCount == 0) {
            resultsText.text = "YOU WIN";
        }
        scoreText.text = $"SCORE\n{score:0000}";
        hiScoreText.text = $"HI-SCORE\n{hiScore:0000}";
    }
    
    // Update is called once per frame
    void Update() {
        SetScoreText();
    }
    
    void FixedUpdate() {
        GameObject Ebarrage = GameObject.Find("Enemy Barrage(Clone)");
        Vector3 enemyPos = Ebarrage.transform.position;
        float multiplier = 1f;
        int clampVal = 7;

        if (enemyCount < 18) {
            multiplier = 2f;
        }

        if (enemyCount < 9) {
            multiplier = 3f;
        }
        
        if (dir == "right" && enemyPos.x < clampVal) {
            Vector3 newPos = new Vector3(1, 0, 0);
            enemyPos += newPos * Time.deltaTime * multiplier;
        }

        if (dir == "left" && enemyPos.x > -clampVal) {
            Vector3 newPos = new Vector3(-1, 0, 0);
            enemyPos += newPos * Time.deltaTime * multiplier;
        }

        enemyPos.x = Mathf.Clamp(enemyPos.x, -clampVal, clampVal);
        
        if (enemyPos.x == clampVal) {
            Vector3 newPos = new Vector3(0, -1, 0);
            enemyPos += newPos;
            dir = "left";
        }

        if (enemyPos.x == -clampVal) {
            Vector3 newPos = new Vector3(0, -1, 0);
            enemyPos += newPos;
            dir = "right";
        }

        // Updating enemy position
        Ebarrage.transform.position = enemyPos;
    }
}
