using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static bool gameIsOver;
    public GameObject gameOverUI;

    private void Start() {
        gameIsOver = false;
    }

    void Update() {
        if (gameIsOver)
            return;
        
        if (PlayerStats.Lives <= 0)
            EndGame();
    }

    void EndGame() {
        gameIsOver = true;
        gameOverUI.SetActive(true);
    }
}
